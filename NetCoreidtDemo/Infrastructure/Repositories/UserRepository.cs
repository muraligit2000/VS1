using Data.DomainModels;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using m = Data.DomainModels;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _config;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;


        public UserRepository(IConfiguration config,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager
            )
        {
            _config = config;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<LoginToken> LoginUser(LoginDTO loginDTO)
        {
            var loginToken = new LoginToken();

            try
            {

                var user = await _userManager.FindByNameAsync(loginDTO.Username);
                if (user != null && await _userManager.CheckPasswordAsync(user, loginDTO.Password))
                {
                    var userRoles = await _userManager.GetRolesAsync(user);
                    var authClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    };

                    foreach (var userRole in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                    }

                    var authSignInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SecurityKey"]));
                    var token = new JwtSecurityToken(
                        issuer: _config["JWT:ValidIssuer"],
                        audience: _config["JWT:ValidAudience"],
                        expires: DateTime.Now.AddSeconds(10),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSignInKey, SecurityAlgorithms.HmacSha256)
                        );

                    var ReturnToken = new JwtSecurityTokenHandler().WriteToken(token);
                    loginToken.Token = ReturnToken;

                    return loginToken;
                }
            }
            catch (Exception ex)
            {
                string str = ex.StackTrace;
            }

            return null;
        }
        public async Task<IdentityResult> AddUser(SignUpDTO signUpDTO)
        {
            try
            {
                var userExist = _userManager.FindByNameAsync(signUpDTO.Username);
                if (userExist.Result != null)
                {
                    var idtErr = new List<IdentityError>()
                    {
                        new IdentityError(){ Code = "Duplicate User", Description = "User already exists" }
                    };
                    return IdentityResult.Failed(idtErr.ToArray());
                }

                var user = new m.ApplicationUser()
                {
                    UserName = signUpDTO.Username,
                    FirstName = signUpDTO.Firstname,
                    LastName = signUpDTO.Lastname,
                    Email = signUpDTO.Email,
                    PhoneNumber = signUpDTO.Phone,

                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 10
                };

                string strRolename = signUpDTO.Role.Rolename.ToString();

                if (!await _roleManager.RoleExistsAsync(strRolename))
                    await _roleManager.CreateAsync(new IdentityRole(strRolename));

                var result = _userManager.CreateAsync(user, signUpDTO.Password);

                if (result.Result.Succeeded)
                {
                    var resultRole = await _userManager.AddToRoleAsync(user, strRolename);

                    return IdentityResult.Success;
                }
                else
                    return IdentityResult.Failed(result.Result.Errors.ToArray());
            }
            catch (Exception ex)
            {
                string strex = ex.StackTrace;
            }
            return null;
        }
    }
}

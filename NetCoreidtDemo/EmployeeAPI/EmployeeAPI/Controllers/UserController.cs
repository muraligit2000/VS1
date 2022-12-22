using EmployeeAPI.ViewModels;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class UserController : Controller
    {
        private IConfiguration _Config;
        private readonly IUserRepository _userRepository;
        public UserController(IConfiguration config, IUserRepository userRepository)
        {
            _Config = config;
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginUser(LoginDTO dto)
        {
            var result = await _userRepository.LoginUser(dto);

            if (string.IsNullOrEmpty(result.Error))
                return Ok(result);
            else
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDTO()
                {
                    Status = result.Error,
                    Message = result.Error
                });

        }

        [HttpPost]
        [Route("add-user")]
        [SwaggerOperation(Summary = "Adding a new user", Description = "Adding a new user")]
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(400, "Bad Request", typeof(ResponseDTO))]
        public async Task<IActionResult> AddUser(SignUpDTO dto)
        {
            var result = await _userRepository.AddUser(dto);

            if (result.Succeeded)
            {
                return StatusCode(StatusCodes.Status200OK, new ResponseDTO()
                {
                    Status = "Success",
                    Message = "User created successfully"
                });
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDTO()
                {
                    Status = result.Errors?.FirstOrDefault().Code,
                    Message = result.Errors?.FirstOrDefault().Description
                });
            }
        }

    }
}

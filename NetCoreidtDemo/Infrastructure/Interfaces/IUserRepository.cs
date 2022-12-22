using Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        Task<IdentityResult> AddUser(SignUpDTO signUpDTO);

        Task<LoginToken> LoginUser(LoginDTO loginDTO);
    }
}

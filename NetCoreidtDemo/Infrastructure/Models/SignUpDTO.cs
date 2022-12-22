using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.Models
{
    public class SignUpDTO
    {
        [Required(ErrorMessage = "Username is mandatory.")]
        public string Username  { get; set; }
        [Required(ErrorMessage = "Email is mandatory."), 
            EmailAddress(ErrorMessage = "Valid email address is needed")] 
        public string Email { get; set; }
        [Required(ErrorMessage = "Firstname is mandatory.")] 
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Lastname is mandatory.")] 
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Password is mandatory.")] 
        public string Password { get; set; }
        public string Phone { get; set; }
        public UserRoles Role { get; set; }

    }
}

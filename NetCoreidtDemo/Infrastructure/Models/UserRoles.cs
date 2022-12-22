using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Models
{
    public class UserRoles
    {
        public const string Admin = "admin";

        public const string User = "user";

        public const string SuperAdmin = "superadmin";

        public string Rolename { get; set; }
    }
}

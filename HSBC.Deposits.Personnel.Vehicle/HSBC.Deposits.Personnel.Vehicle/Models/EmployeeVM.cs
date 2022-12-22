using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HSBC.Deposits.Personnel.Vehicle.Models
{
    public class EmployeeVM
    {
        [Required]
        public int EmpNo { get; set; }
        [Required]
        public string EmpName { get; set; }
        [Required]
        public string Department { get; set; }
    }
}

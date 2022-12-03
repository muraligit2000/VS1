using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.BusinessModels
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string CompanyId { get; set; }
        public string EmpNo { get; set; }
        public string Empname { get; set; }
        public bool? Gender { get; set; }
        public string ResAddress { get; set; }
       
    }
}

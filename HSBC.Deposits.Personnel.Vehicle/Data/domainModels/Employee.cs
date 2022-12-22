using System;
using System.Collections.Generic;

namespace Data.domainModels
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string CompanyId { get; set; }
        public string EmpNo { get; set; }
        public string Empname { get; set; }
        public bool? Gender { get; set; }
        public string ResAddress { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public string Ipaddress { get; set; }
        public string SourceApplicationName { get; set; }
        public string SourcePageName { get; set; }
    }
}

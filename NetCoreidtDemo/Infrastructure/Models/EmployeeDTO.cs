using System;
using System.Collections.Generic;

namespace Infrastructure.Models
{

    public class TravelHubTileCaptions
    {
        public string LanguageCode { get; set; }
        public string EnglishData { get; set; }
        public string OtherLanguageData { get; set; }

        //public string en_GB_LanguageCode { get; set; }
        //public string en_GB_EnglishData { get; set; }
        //public string en_GB_OtherLanguageData { get; set; }
        //public string Empname { get; set; }

        //public string fr_FR_LanguageCode { get; set; }
        //public string fr_FR_EnglishData { get; set; }
        //public string fr_FR_OtherLanguageData { get; set; }

    }

    public class EmployeeDTO
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

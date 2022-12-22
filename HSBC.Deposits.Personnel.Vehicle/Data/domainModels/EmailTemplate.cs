using System;
using System.Collections.Generic;

namespace Data.domainModels
{
    public partial class EmailTemplate
    {
        public int Id { get; set; }
        public string EmailTemplate1 { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
    }
}

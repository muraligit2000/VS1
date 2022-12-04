using System;
using System.Collections.Generic;

namespace DataLayer.BusinessModels
{
    public class EmpDTO
    {
        public int Empno { get; set; }
        public string Ename { get; set; }
        public string Job { get; set; }
        public int? Mgr { get; set; }
        public DateTime? Hiredate { get; set; }
        public int? Sal { get; set; }
        public int? Comm { get; set; }
        public int? Deptno { get; set; }

        public string Deptname { get; set; }
        public string Location { get; set; }

    }
}

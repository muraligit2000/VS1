using System;
using System.Collections.Generic;

namespace Data.domainModels
{
    public partial class EmpDept
    {
        public int? Empno { get; set; }
        public string Ename { get; set; }
        public string Job { get; set; }
        public int? Mgr { get; set; }
        public DateTime? Hiredate { get; set; }
        public int? Sal { get; set; }
        public int? Comm { get; set; }
        public int? Deptno { get; set; }
        public int? DeptDeptno { get; set; }
        public string Dname { get; set; }
        public string Loc { get; set; }
    }
}

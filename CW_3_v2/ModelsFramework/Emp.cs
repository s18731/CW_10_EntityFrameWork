using System;
using System.Collections.Generic;

namespace CW_3_v2.ModelsFramework
{
    public partial class Emp
    {
        public int Empno { get; set; }
        public string Ename { get; set; }
        public string Job { get; set; }
        public int? Mgr { get; set; }
        public DateTime? Hiredate { get; set; }
        public int? Sal { get; set; }
        public int? Comm { get; set; }
        public int? Deptno { get; set; }
    }
}

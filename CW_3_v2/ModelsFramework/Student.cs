using System;
using System.Collections.Generic;

namespace CW_3_v2.ModelsFramework
{
    public partial class Student
    {
        public string IndexNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int IdEnrollment { get; set; }

        public virtual Enrollment IdEnrollmentNavigation { get; set; }
    }
}

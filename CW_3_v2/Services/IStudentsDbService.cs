using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CW_3_v2.Models;
using CW_3_v2.ModelsFramework;

namespace CW_3_v2.Services
{
    public interface IStudentsDbService
    {
        public bool IsStudentNumberUnique(string studentNumber);
        public bool StudiesAvailable (string studiesName);
        public bool CreateEnrollment (EnrollmentPost student);
        public Models.Enrollment ReturnedEnrollmentResult(EnrollmentPost student);
        public bool ConatinsEnrollment(PromotePost promotePost);
        public bool ExecuteDatabaseProcedurePromote(PromotePost promotePost);
        public Models.Enrollment PromotedEnrollmentStudent(PromotePost promotePost);
        public IEnumerable<ModelsFramework.Student> GetStudents();
        public bool UpdateStudent(ModelsFramework.Student student);

        public bool RemoveStudent(string indexNumber);
    }
}

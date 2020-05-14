using CW_3_v2.Models;
using CW_3_v2.ModelsFramework;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CW_3_v2.Services
{
    public class EfStudentsDbService : IStudentsDbService
    {
        /* missing procedure EnrollStudents*/

        private readonly s18731Context _context;
        public EfStudentsDbService(s18731Context context)
        { 
            _context = context;
        }
        public bool ConatinsEnrollment(PromotePost promotePost)
        {
            throw new NotImplementedException();
        }

        public bool CreateEnrollment(EnrollmentPost student)
        {
            throw new NotImplementedException();
        }

        public bool ExecuteDatabaseProcedurePromote(PromotePost promotePost)
        {
            var par1 = new SqlParameter("@studies", promotePost.Studies);
            var par2 = new SqlParameter("@semester", promotePost.Semester);
            _context.Database.ExecuteSqlRaw("EXECUTE promoteForNextSemester @studies , @semester", par1, par2);
            return true;
        }

        public IEnumerable<ModelsFramework.Student> GetStudents()
        {
            return _context.Student.ToList();
        }

        public bool IsStudentNumberUnique(string studentNumber)
        {
            throw new NotImplementedException();
        }

        public bool RemoveStudent(string indexNumber)
        {
            ModelsFramework.Student st = _context.Student.Where(x => x.IndexNumber == indexNumber).First();
            
            _context.Student.Remove(st);
            return true;
        }

        public bool StudiesAvailable(string studiesName)
        {
            throw new NotImplementedException();
        }

        public bool UpdateStudent(ModelsFramework.Student student)
        {
            /* way for checking if update was executed correctly */
            _context.Update(student);
            _context.SaveChanges();
            
            /*ModelsFramework.Student s = (from x in ModelsFramework.Student where x.IndexNumber == student.IndexNumber).First();
            s.IndexNumber = student.IndexNumber;
            s.FirstName = student.FirstName;
            s.LastName = student.LastName;*/

            return true;
        }

        Models.Enrollment IStudentsDbService.PromotedEnrollmentStudent(PromotePost promotePost)
        {
            throw new NotImplementedException();
        }

        Models.Enrollment IStudentsDbService.ReturnedEnrollmentResult(EnrollmentPost student)
        {
            throw new NotImplementedException();
        }
    }
}

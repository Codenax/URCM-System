using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCR_ManagementSystem.DatabaseContexts.DatabaseContext;
using UCR_ManagementSystem.Models.Models;
using System.Data.Entity;
namespace UCR_ManagementSystem.DAL.DAL
{
    public class StudentDAL
    {
        UCRMSystemDbContext db = new UCRMSystemDbContext();

        ///----Save Student----///
        public bool Add(Student student)
        {
            db.Students.Add(student);

            return db.SaveChanges() > 0;
        }
        ///----Save Student End----///
        ///
        public List<Student> StudentGetAll()
        {
            return db.Students.Include(c => c.Department).ToList();
        }

        ///---Student Enroll---///
        public bool Add(StudentEnroll studentEnroll)
        {
            db.StudentEnrolls.Add(studentEnroll);

            return db.SaveChanges() > 0;
        }

        public List<StudentEnroll> StudentEnrollListGetAll()
        {
            return db.StudentEnrolls.Include(c => c.Student).ToList();
        }
        ///---Student Enroll End---///
         ///-----Save Student result---////

        public bool Add(SaveStudentResult saveStudentResult)
        {
            db.SaveStudentResults.Add(saveStudentResult);

            return db.SaveChanges() > 0;
        }

         ///-----Save Student result end---////

    }
}
     
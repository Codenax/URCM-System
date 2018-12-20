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
            if (db.Students.FirstOrDefault(c => c.StudentEmail.ToLower().Contains(student.StudentEmail.ToLower())) == null)
            {
                db.Students.Add(student);
                return db.SaveChanges() > 0;
            }
            else
            {
                return false;
            }

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
            if (db.StudentEnrolls.Any(c => c.StudentId == studentEnroll.StudentId && c.CourseId == studentEnroll.CourseId))
            {

                return false;
                //db.StudentEnrolls.Add(studentEnroll);
                //return db.SaveChanges() > 0;
            }
            else if (db.StudentEnrolls.Any(c => c.StudentId == studentEnroll.StudentId && c.CourseId != studentEnroll.CourseId))
            {
                db.StudentEnrolls.Add(studentEnroll);
                return db.SaveChanges() > 0;
            }
            else
            {
                db.StudentEnrolls.Add(studentEnroll);
                return db.SaveChanges() > 0;
            }
            //else
            //{
            //    return false;
            //}
        }

        public List<StudentEnroll> StudentEnrollListGetAll()
        {

            return db.StudentEnrolls.Include(c => c.Student).ToList();
        }
        ///---Student Enroll End---///
         ///-----Save Student result---////

        public bool Add(SaveStudentResult saveStudentResult)
        {

            if (db.SaveStudentResults.Any(c => c.StudentId == saveStudentResult.StudentId && c.CourseId == saveStudentResult.CourseId))
            {

                return false;
                //db.StudentEnrolls.Add(studentEnroll);
                //return db.SaveChanges() > 0;
            }
            else if (db.SaveStudentResults.Any(c => c.StudentId == saveStudentResult.StudentId && c.CourseId != saveStudentResult.CourseId))
            {
                db.SaveStudentResults.Add(saveStudentResult);
                return db.SaveChanges() > 0;
            }
            else
            {
                db.SaveStudentResults.Add(saveStudentResult);
                return db.SaveChanges() > 0;
            }

        }

        public List<SaveStudentResult> SaveStudentResultGetAll()
        {
            return db.SaveStudentResults.Include(c => c.Student).ToList();
        }
        ///
         ///-----Save Student result end---////

    }
}
     
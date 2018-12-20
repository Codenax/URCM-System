using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCR_ManagementSystem.DatabaseContexts.DatabaseContext;
using UCR_ManagementSystem.Models.Models;

namespace UCR_ManagementSystem.DAL.DAL
{
   public class CoueseTeacherDAL
    {
        UCRMSystemDbContext db = new UCRMSystemDbContext();


       ///----Save Course----///
        public bool Add(Course course)
        {
            if (db.Courses.FirstOrDefault(c => c.CourseCode.ToLower().Contains(course.CourseCode.ToLower())) == null && db.Courses.FirstOrDefault(c => c.CourseName.ToLower().Contains(course.CourseName.ToLower())) == null)
            {
                db.Courses.Add(course);
                return db.SaveChanges() > 0;
            }
            else
            {
                return false;
            }

        }
        public List<Course> CourseGetAll()
        {
            return db.Courses.Include(c => c.Department).ToList();
        }

        ///----Save Course End----///
        ///----Save Teacher----///
        public bool Add(Teacher teacher)
        {
            if (db.Teachers.FirstOrDefault(c => c.Email.ToLower().Contains(teacher.Email.ToLower())) == null)
            {
                db.Teachers.Add(teacher);
                return db.SaveChanges() > 0;
            }
            else
            {
                return false;
            }

        }
        ///----Save Teacher End----///
        ///----Save AssignTeacher ---///

        public List<Teacher> TeacherGetAll()
        {
            return db.Teachers.Include(c => c.Department).ToList();
        }


        public bool Add(AssignTeacher assignTeacher)
        {
            if (db.AssignTeachers.Where(c => !c.IsUnassign).FirstOrDefault(c => c.CourseName.ToLower().Contains(assignTeacher.CourseName.ToLower())) == null)
            {
                db.AssignTeachers.Add(assignTeacher);
                return db.SaveChanges() > 0;
            }
            else
            {
                return false;
            }

        }

        public List<AssignTeacher> AssingTeacherGetAll()
        {
            return db.AssignTeachers.Where(c => !c.IsUnassign).Include(c=> c.Teacher).ToList();
        }

        ///----Save AssignTeacher End ---///

        public int Complete()
        {
            return db.SaveChanges();
        }
    }
}

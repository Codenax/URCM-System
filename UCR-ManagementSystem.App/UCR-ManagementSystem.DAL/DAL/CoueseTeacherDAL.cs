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
            db.Courses.Add(course);
            
            return db.SaveChanges() > 0;
        }
        public List<Course> GetAll()
        {
            return db.Courses.Include(c => c.Department).ToList();
        }
        //public List<Employee> GetAll()
        //{
        //    return db.Employees.Include(c => c.Department).ToList();
        //}

        ///----Save Course End----///
        ///----Save Teacher----///
        public bool Add(Teacher teacher)
        {
            db.Teachers.Add(teacher);

            return db.SaveChanges() > 0;
        }
        ///----Save Teacher End----///

    }
}

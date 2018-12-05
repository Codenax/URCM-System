using System;
using System.Collections.Generic;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Data.Entity;
using UCR_ManagementSystem.DatabaseContexts.DatabaseContext;
using UCR_ManagementSystem.Models.Models;

namespace UCR_ManagementSystem.DAL.DAL
{
    public class DepartmentDAL
    {

        UCRMSystemDbContext db = new UCRMSystemDbContext();
        public bool Add(Department department)
        {
            db.Departments.Add(department);
            return db.SaveChanges() > 0;
        }
        public List<Department> GetAll()
        {
            return db.Departments
                .Include(c => c.Courses)
                .ToList();
        }
        //public List<Department> GetAll()
        //{
        //    return db.Departments
        //        .Include(c => c.Employees)
        //        .ToList();
        //}
    }

}

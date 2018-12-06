using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCR_ManagementSystem.DatabaseContexts.DatabaseContext;
using UCR_ManagementSystem.Models.Models;

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
    }
}

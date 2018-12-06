using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCR_ManagementSystem.DAL.DAL;
using UCR_ManagementSystem.Models.Models;

namespace UCR_ManagementSystem.BLL.BLL
{
   public class StudentManager
    {
        StudentDAL studentDAL = new StudentDAL();
        ///----Save Teacher----///
        public bool Add(Student student)
        {
            bool isSavedS = studentDAL.Add(student);
            return isSavedS;
        }
        ///----Save Teacher End----
    } 
}

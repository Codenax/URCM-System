using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCR_ManagementSystem.Models.Models;
using UCR_ManagementSystem.DAL.DAL;
namespace UCR_ManagementSystem.BLL.BLL
{
   public class DepartmentManager
    {
       DepartmentDAL departmentDAL = new DepartmentDAL();
        public bool Add(Department department)
        {
            bool isSaved = departmentDAL.Add(department);
            return isSaved;

        }
        // public bool GetAll()
        //{
        //    departmentDAL.GetAll();
        //    return true;
        //}
   }  
}

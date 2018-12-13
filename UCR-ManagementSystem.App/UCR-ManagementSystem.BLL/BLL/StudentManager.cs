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
        DepartmentDAL departmentDal = new DepartmentDAL();
        ///----Save Student----///
        ///

        public int RegNumber(int departmentId)
        {
            int number;
            var student = studentDAL.StudentGetAll().Where(c => c.DepartmentId == departmentId).LastOrDefault();
            if (student != null)
            {
                var regSplit = student.RegistrationNumber.Split('-');
                number = Convert.ToInt32(regSplit[2])+1;
                return number;
            }

            number = 1;
            return number;
        }

        public bool Add(Student student)
        {
            var department = departmentDal.GetById(student.DepartmentId);
            student.RegistrationNumber = department.DepartmentCode + "-" + 
                student.RegData.Year + "-" +
                RegNumber(student.DepartmentId).ToString().PadLeft(3, '0');

            bool isSavedS = studentDAL.Add(student);
            return isSavedS;
        }
        ///----Save Student End----///
        ///---- Student Enroll ----///
        public bool Add(StudentEnroll studentEnroll)
        {
            bool isSavedSE = studentDAL.Add(studentEnroll);
            return isSavedSE;
        }
        ///---- Student Enroll End----///
        ///----- Save student result---///

        public bool Add(SaveStudentResult saveStudentResult)
        {
            bool isSavedSSR = studentDAL.Add(saveStudentResult);
            return isSavedSSR;
        }

        ///----- Save student result End---/// 

    } 
}

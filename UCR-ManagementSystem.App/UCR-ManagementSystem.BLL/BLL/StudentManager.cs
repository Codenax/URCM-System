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
        ///----Save Student----///
        public bool Add(Student student)
        {
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

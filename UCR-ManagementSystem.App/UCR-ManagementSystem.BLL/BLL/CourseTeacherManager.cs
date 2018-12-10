using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCR_ManagementSystem.DAL.DAL;
using UCR_ManagementSystem.Models.Models;

namespace UCR_ManagementSystem.BLL.BLL
{
   public class CourseTeacherManager
    {
        CoueseTeacherDAL coueseTeacherDAL = new CoueseTeacherDAL();

        ///----Save Course----///
        public bool Add(Course course)
        {
            bool isSaved = coueseTeacherDAL.Add(course);
            return isSaved;
        }
        ///----Save Course End----///
        ///----Save Teacher----///
        public bool Add(Teacher teacher)
        {
            bool isSavedT = coueseTeacherDAL.Add(teacher);
            return isSavedT;
        }
        ///----Save Teacher End----///
        ///

        public bool Add(AssignTeacher assignTeacher)
        {
            bool isSavedT = coueseTeacherDAL.Add(assignTeacher);
            return isSavedT;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCR_ManagementSystem.DAL.DAL;
using UCR_ManagementSystem.Models.Models;
using System.Globalization;
using System.Data.Entity.Core.Objects;
using System.Data.Entity;

namespace PracticeConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            int studentId = 3;
            StudentDAL studentDAL = new StudentDAL();
            DepartmentDAL departmentDAL = new DepartmentDAL();
            CoueseTeacherDAL courseTeacherDAL = new CoueseTeacherDAL();
            var StudentEnroll = from s in studentDAL.StudentEnrollListGetAll()
                        join c in courseTeacherDAL.CourseGetAll() on s.CourseId equals c.CourseId
                        select new
                        {
                            StudentId = s.StudentId,
                            StudentName = s.StudentName,
                            StudentEmail = s.StudentEmail,
                            DepartmentName = s.DepartmentName,
                            CourseCode = c.CourseCode,
                            CourseName = c.CourseName,
                            CourseId = c.CourseId,
                        };

            var StudentEnrollByStudentId = StudentEnroll.Where(c => c.StudentId == studentId).ToList();
            var StudentResulByStudentId = studentDAL.SaveStudentResultGetAll().Where(c => c.StudentId == studentId).ToList();

            var result = from e in StudentEnrollByStudentId
                         join d in StudentResulByStudentId
                         on e.CourseId equals d.CourseId into eGroup
                         from d in eGroup.DefaultIfEmpty()
                         select new
                         {
                             StudentId = e.StudentId,
                             StudentName = e.StudentName,
                             StudentEmail = e.StudentEmail,
                             DepartmentName = e.DepartmentName,
                             CourseId = e.CourseId,
                             CourseCode = e.CourseCode,   
                             CourseName = e.CourseName,
                             GradeLatter = d == null ? "Not  Graded  Yet" : d.GradeLetter
                         };

            foreach (var c in result)
            {
                Console.WriteLine(c.StudentId + "\t" + c.StudentName + "\t"
                                  + c.StudentEmail + "\t" + c.DepartmentName + "\t"
                                  + c.CourseId + "\t" + c.CourseCode + "\t" + c.CourseName + "\t" + c.GradeLatter 
                                  );
            }
            Console.ReadKey(); 
            //foreach (var c in result)
            //{
            //    Console.WriteLine(c.StudentId + "\t" + c.StudentName + "\t"
            //                      + c.StudentEmail + "\t" + c.DepartmentName + "\t"
            //                      + c.CourseCode + "\t" + c.CourseName + "\t" + c.GradeLatter 
            //                      );
            //}
            //Console.ReadKey();

        }
    }
}

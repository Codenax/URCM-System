using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCR_ManagementSystem.Models.Models;
using UCR_ManagementSystem.DAL.DAL;

namespace pratice
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int departmentId = 3;
            CoueseTeacherDAL courseTeacherDAL = new CoueseTeacherDAL();
            var result = from e in  courseTeacherDAL.CourseGetAll()
                         join d in courseTeacherDAL.AssingTeacherGetAll()
                         on e.CourseId equals d.CourseId into eGroup
                         from d in eGroup.DefaultIfEmpty()
                         select new
                         {
                             DepartmentId = e.DepartmentId,
                             DepartmentName = e.Department.DepartmentName,
                             CourseCode = e.CourseCode,
                             CourseName = e.CourseName,
                             Semester = e.Semester,
                             AssignTo = d == null ? "Not Assigned Yet" : d.Teacher.TeacherName
                             //AssignTo = d == null? "no" | d.TeacherId
                         };
            var dataList = result.Where(c => c.DepartmentId == departmentId).ToList();
            var jsonData = dataList.Select(c => new {c.DepartmentId, c.DepartmentName, c.CourseCode, c.CourseName, c.Semester, c.AssignTo });


            foreach (var v in jsonData) 
            {
                Console.WriteLine(v.DepartmentId + "\t" + v.DepartmentName + v.CourseCode + "\t" + v.CourseName + "\t" + v.Semester + "\t" + v.AssignTo);
            }
            Console.ReadKey();
            //var result = courseTeacherDAL.CourseGetAll()
            //            .GroupJoin(courseTeacherDAL.AssingTeacherGetAll(),
            //            e => e.CourseId,
            //            d => d.CourseId,
            //            (emp, dept) => new
            //            {
            //                emp,
            //                dept
            //            })
            //            .Select(z => z.dept.DefaultIfEmpty(),
            //            (a, b) => new
            //            {
            //                CourseCode = a.emp.CourseName,

            //            });


        }
    }
}

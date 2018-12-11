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
            int id = 4;

            CoueseTeacherDAL courseTeacherDAL = new CoueseTeacherDAL();
            StudentDAL studentDAL = new StudentDAL();
            var query = from s in studentDAL.SaveStudentResultGetAll()
                        join c in courseTeacherDAL.CourseGetAll() on s.CourseId equals c.CourseId
                        //where s.StudentId == id
                        select new
                        {
                            StudentId = s.StudentId,
                            RegistrationNumber = s.Student.RegistrationNumber,
                            StudentName = s.StudentName,
                            StudentEmail = s.StudentEmail,
                            DepartmentName = s.DepartmentName,
                            CourseCode = c.CourseCode,
                            CourseName =c.CourseName,
                            GradeLatter = s.GradeLetter,
                        };

            foreach (var v in query)
            {
                Console.WriteLine(v.StudentId + "\t" + v.RegistrationNumber + "\t"
                                  + v.StudentName + "\t" + v.StudentEmail + "\t"
                                  + v.DepartmentName + "\t" + v.CourseCode + "\t"
                                  + v.CourseName + "\t" + v.GradeLatter + "\t"
                                  );
            }
            Console.ReadKey();



            //var query = from s in studentDAL.StudentEnrollListGetAll()
            //            join c in courseTeacherDAL.CourseGetAll() on s.CourseId equals c.CourseId
            //            //where s.StudentId == id
            //            select new
            //            {
            //                StudentId = s.StudentId,
            //                StudentName = s.StudentName,
            //                DepartmentName = s.DepartmentName,
            //                CourseId = s.CourseId,
            //                CourseIdC = c.CourseId,
            //                CourseNameC = c.CourseName,
            //                DepartmentNameC = c.Department.DepartmentName,
                            
            //            };

            //foreach (var v in query)
            //{
            //    Console.WriteLine(v.StudentId + "\t" + v.StudentName + "\t" + v.DepartmentName + "\t" + v.CourseId + "\t" + v.CourseIdC + "\t" + v.CourseNameC + "\t" + v.DepartmentNameC);
            //}
            //Console.ReadKey();


            //var result = studentDAL.StudentEnrollListGetAll()
            //    .Select(n => new
            //    {
            //        studentId= n.StudentId,
            //        studentName = n.Student.StudentName,
            //        registretionNo = n.Student.RegistrationNumber
            //    });
            //foreach (var v in result)
            //{
            //    Console.WriteLine(v.studentId + "\t" + v.studentName +"\t"+ v.registretionNo);
            //}
            //Console.ReadKey();


            //var query = from s in studentDAL.StudentGetAll()
            //            join c in courseTeacherDAL.CourseGetAll() on s.DepartmentId equals c.DepartmentId
            //            where s.StudentId == id
            //            select new { StudentId = s.StudentId, StudentName = s.StudentName,
            //                         DepartmentName= s.Department.DepartmentName, 
            //                         DepartmentNameC = c.Department.DepartmentName, 
            //                         CourseNameC= c.CourseName};

            //foreach (var v in query)
            //{
            //    Console.WriteLine(v.StudentId + "\t" + v.StudentName + "\t" + v.DepartmentName + "\t" + v.DepartmentNameC + "\t" + v.CourseNameC);
            //}
            //Console.ReadKey();

            //CoueseTeacherDAL courseTeacherDAL = new CoueseTeacherDAL();
            //var teacherGetAll = courseTeacherDAL.TeacherGetAll();
            //foreach (var v in teacherGetAll)
            //{
            //    Console.WriteLine(v.TeacherId + "\t" + v.TeacherName +"\t"+ v.CreditTaken);
            //}
            //Console.ReadKey();

            //var AssignCourseCreditresult = courseTeacherDAL.AssingTeacherGetAll();
            //var gropbySum = AssignCourseCreditresult
            //                .GroupBy(s => new { s.TeacherId})
            //                .Select(g => new
            //                  {
            //                      TeacherId = g.Key.TeacherId,
            //                      AssignCourseCredit = g.Sum(x=> x.AssignCourseCredit)
            //                  });
            //foreach (var v in gropbySum)
            //{
            //    Console.WriteLine(v.TeacherId + "\t" + v.AssignCourseCredit );
            //}
            //Console.ReadKey();

            //var result = from e in teacherGetAll
            //             join d in gropbySum
            //             on e.TeacherId equals d.TeacherId into eGroup
            //             from d in eGroup.DefaultIfEmpty()
            //             select new
            //             {
            //                 TeacherId = e.TeacherId,
            //                 TeacherName = e.TeacherName,
            //                 CreditTeken = e.CreditTaken,
            //                 AssignCreditTeken = d == null ? 0 : d.AssignCourseCredit,
            //                  //AssignTo = d == null ? "Not Assigned Yet" : d.Teacher.TeacherName
            //             };

            //foreach (var v in result)
            //{
            //    Console.WriteLine(v.TeacherId + "\t" + v.TeacherName + "\t" + v.CreditTeken + "\t" + v.AssignCreditTeken);
            //}
            //Console.ReadKey();

            //var newResult = result.Select(n => new
            //                       {
            //                         TeacherId =  n.TeacherId,
            //                          TeacherName = n.TeacherName,
            //                          CreditTeken = n.CreditTeken,
            //                          AssignCredit = n.AssignCreditTeken,
            //                          RemainingCredit = n.CreditTeken - n.AssignCreditTeken,
            //                       });
            //var finalresult = newResult.Where(c => c.TeacherId == teacherTd).ToList();
            //foreach (var v in finalresult)
            //{
            //    Console.WriteLine(v.TeacherId + "\t" + v.TeacherName + "\t" + v.CreditTeken + "\t" + v.AssignCredit + "\t" + v.RemainingCredit);
            //}
            //Console.ReadKey();                       



            //            var result = from e in courseTeacherDAL.CourseGetAll()
            //             join d in courseTeacherDAL.AssingTeacherGetAll()
            //             on e.CourseId equals d.CourseId into eGroup
            //             from d in eGroup.DefaultIfEmpty()
            //             select new
            //             {
            //                 DepartmentId = e.DepartmentId,
            //                 DepartmentName = e.Department.DepartmentName,
            //                 CourseCode = e.CourseCode,
            //                 CourseName = e.CourseName,
            //                 Semester = e.Semester,
            //                 AssignTo = d == null ? "Not Assigned Yet" : d.Teacher.TeacherName
            //             };
            //var dataList = result.Where(c => c.DepartmentId == departmentId).ToList();
            //var jsonData = dataList.Select(c => new { c.CourseCode, c.CourseName, c.Semester, c.AssignTo });

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

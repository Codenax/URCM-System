using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCR_ManagementSystem.App.Models;
using UCR_ManagementSystem.BLL.BLL;
using UCR_ManagementSystem.DAL.DAL;
using UCR_ManagementSystem.Models.Models;

using System.Data.Entity;

namespace UCR_ManagementSystem.App.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/



        StudentManager studentManager = new StudentManager();
        StudentDAL studentDAL = new StudentDAL();
        DepartmentDAL departmentDAL = new DepartmentDAL();
        CoueseTeacherDAL courseTeacherDAL = new CoueseTeacherDAL();
        ////----------------Save Student--------------/////

        [HttpGet]
        public ActionResult RegStudent()
        {
            
            var model = new StudentViewModel();
            model.RegData = DateTime.Now;
            model.DepartmentSelectListItems = departmentDAL.GetAll()
                                                .Select(c => new SelectListItem()
                                                {
                                                    Value = c.Id.ToString(),
                                                    Text = c.DepartmentName
                                                });

            return View(model);
        }
        [HttpPost]
        public ActionResult RegStudent(Student student)
        {
            var Fmessage = "";

            if (ModelState.IsValid)
            {
                //var course = Mapper.Map<Course>(model);

                bool isSavedS = studentManager.Add(student);
                if (isSavedS)
                {
                    ViewBag.SMessage = "Student Information Saved Successfully!";
                }
                else
                {
                    Fmessage = "Student Information Saved Failed";
                }
            }
            else
            {
                Fmessage = "Failed";
            }

            var model = new StudentViewModel();
            model.RegData = DateTime.Now;
            model.DepartmentSelectListItems = departmentDAL.GetAll()
                                                .Select(c => new SelectListItem()
                                                {
                                                    Value = c.Id.ToString(),
                                                    Text = c.DepartmentName
                                                });
            ViewBag.FMessage = Fmessage;
            return View(model);
        }
   
    ////----------------Save Student End---------------/////

        [HttpGet]
        public ActionResult StudentEnrollInaCourse()
        {
            var model = new StudentViewModel();
            model.RegistrationNumberList = studentDAL.StudentGetAll().Select(c => new SelectListItem() { Value = c.StudentId.ToString(), Text = c.RegistrationNumber });
            model.CoursetSelectListItems = GetDefaultSelectListItem();
            return View(model);

        }
        private IEnumerable<SelectListItem> GetDefaultSelectListItem()
        {
            return new List<SelectListItem> { new SelectListItem { Value = "", Text = "Select..." } };
        }
        public JsonResult GetStudentInfoByStudentId(int studentId)
        {
            var dataList = studentDAL.StudentGetAll();
            dataList = dataList.Where(c => c.StudentId == studentId).ToList();
            var jsonData = dataList.Select(c => new { c.StudentName, c.StudentEmail,c.Department.DepartmentName});
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCourseInfoByStudentId(int studentId)
        {
            //var dataList = studentDAL.StudentGetAll();
            //dataList = dataList.Where(c => c.StudentId == studentId).ToList();
            //var jsonData = dataList.Select(c => new { c.Department.Course.CourseId, c.Department.Course.CourseName });
            //StudentDAL studentDAL = new StudentDAL();
            
            var result = from s in studentDAL.StudentGetAll()
                        join c in courseTeacherDAL.CourseGetAll() on s.DepartmentId equals c.DepartmentId
                        select new
                        {
                            StudentId = s.StudentId,
                            StudentName = s.StudentName,
                            DepartmentName = s.Department.DepartmentName,
                            DepartmentNameC = c.Department.DepartmentName,
                            CourseId = c.CourseId,
                            CourseName = c.CourseName
                        };
            var dataList = result.Where(c => c.StudentId == studentId).ToList();
            var jsonData = dataList.Select(c => new { c.CourseId, c.CourseName });
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }


    }
}
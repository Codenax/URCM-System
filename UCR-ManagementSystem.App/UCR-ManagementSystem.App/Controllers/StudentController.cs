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
    ////----------------Student enroll---------------/////

        [HttpGet]
        public ActionResult StudentEnrollInaCourse()
        {
            var model = new StudentEnrollViewModel();
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

        [HttpPost]
        public ActionResult StudentEnrollInaCourse(StudentEnroll studentEnroll)
        {
            var FEmessage = "";

            if (ModelState.IsValid)
            {
                //var course = Mapper.Map<Course>(model);

                bool isSavedSE = studentManager.Add(studentEnroll);
                if (isSavedSE)
                {
                    ViewBag.SEMessage = "Enroll Course Information Saved Successfully!";
                }
                else
                {
                    FEmessage = "Enroll Course Information Saved Failed";
                }
            }
            else
            {
                FEmessage = "Failed";
            }
            var model = new StudentEnrollViewModel();
            model.RegistrationNumberList = studentDAL.StudentGetAll().Select(c => new SelectListItem() { Value = c.StudentId.ToString(), Text = c.RegistrationNumber });
            model.CoursetSelectListItems = GetDefaultSelectListItem();
            ViewBag.FMessage = FEmessage;
            return View(model);
        }

        ////----------------Student enroll End---------------/////
        ////----------------Save Student result---------------/////
        [HttpGet]
        public ActionResult SaveStudentResult()
        {
            var model = new SaveStudentResultViewModel();
            model.RegistrationNumberList = studentDAL.StudentEnrollListGetAll().Select(c => new SelectListItem() { Value = c.StudentId.ToString(), Text = c.Student.RegistrationNumber });
            model.CoursetSelectListItems = GetDefaultSelectListItem();
            return View(model);
        }
        public JsonResult GetStudentByEnrollStudentId(int studentId)
        {
            var dataList = studentDAL.StudentEnrollListGetAll().Where(c => c.StudentId == studentId).ToList();
            var jsonData = dataList.Select(c => new { c.StudentName,c.StudentEmail,c.DepartmentName});
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourseByEnrollStudentId(int studentId)
        {
            var queryResult = from s in studentDAL.StudentEnrollListGetAll()
                        join c in courseTeacherDAL.CourseGetAll() on s.CourseId equals c.CourseId
                        select new
                        {
                            StudentId = s.StudentId,
                            CourseId = s.CourseId,
                            CourseName = c.CourseName,
                        };
            var dataList = queryResult.Where(c => c.StudentId == studentId).ToList();
            var jsonData = dataList.Select(c => new { c.CourseId, c.CourseName });
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveStudentResult(SaveStudentResult saveStudentResult)
        {
            var SSFmessage = "";

            if (ModelState.IsValid)
            {
                //var course = Mapper.Map<Course>(model);

                bool isSavedSSR = studentManager.Add(saveStudentResult);
                if (isSavedSSR)
                {
                    ViewBag.SSRmessage = "Student Result Information Saved Successfully!";
                }
                else
                {
                    SSFmessage = "Student Result Course Information Saved Failed";
                }
            }
            else
            {
                SSFmessage = "Failed";
            }
            var model = new SaveStudentResultViewModel();
            model.RegistrationNumberList = studentDAL.StudentEnrollListGetAll().Select(c => new SelectListItem() { Value = c.StudentId.ToString(), Text = c.Student.RegistrationNumber });
            model.CoursetSelectListItems = GetDefaultSelectListItem();     
            ViewBag.FMessage = SSFmessage;
            return View(model);
        }

        ////----------------Save Student result End---------------/////
        ////----------------Student result View---------------/////

        public ActionResult StudentResultView()
        {
            var model = new SaveStudentResultViewModel();
            model.RegistrationNumberList = studentDAL.SaveStudentResultGetAll().Select(c => new SelectListItem() { Value = c.StudentId.ToString(), Text = c.Student.RegistrationNumber });
            return View(model);
        }
        public JsonResult GetStudentByResultStudentId(int studentId)
        {
            var query = from s in studentDAL.SaveStudentResultGetAll()
                        join c in courseTeacherDAL.CourseGetAll() on s.CourseId equals c.CourseId
                        select new
                        {
                            StudentId = s.StudentId,              
                            StudentName = s.StudentName,
                            StudentEmail = s.StudentEmail,
                            DepartmentName = s.DepartmentName,
                            CourseCode = c.CourseCode,
                            CourseName = c.CourseName,
                            GradeLatter = s.GradeLetter,
                        };
            var dataList = query.Where(c => c.StudentId == studentId).ToList();
            var jsonData = dataList.Select(c => new { c.StudentName, c.StudentEmail, c.DepartmentName,c.CourseCode,c.CourseName,c.GradeLatter});
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        ////----------------Student result view End---------------/////

    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCR_ManagementSystem.BLL.BLL;
using UCR_ManagementSystem.Models;
using System.Data.Entity;
using UCR_ManagementSystem.Models.Models;
using UCR_ManagementSystem.DAL.DAL;
using UCR_ManagementSystem.App.Models;
using AutoMapper;

namespace UCR_ManagementSystem.App.Controllers
{
    public class CourseTeacherController : Controller
    {
        //
        // GET: /CourseTeacher/

        CourseTeacherManager courseTeacherManager = new CourseTeacherManager();
        DepartmentDAL departmentDAL = new DepartmentDAL();



        ////----------------Save Course---------------/////
        [HttpGet]
        public ActionResult SaveCourse()
        {
            var model = new CourseSaveViewModel();
            model.DepartmentSelectListItems = departmentDAL.GetAll()
                                                .Select(c => new SelectListItem()
                                                {
                                                    Value = c.Id.ToString(),
                                                    Text = c.DepartmentName
                                                });
          
            return View(model);            
        }        
        [HttpPost]
        public ActionResult SaveCourse(Course course)
        {
            var message = "";

            if (ModelState.IsValid)
            {
                //var course = Mapper.Map<Course>(model);

                bool isSaved = courseTeacherManager.Add(course);
                if (isSaved)
                {
                    ViewBag.SMessage = "Course Information Saved Successfully!";                
                }
                else
                {
                    message = "Course Information Saved Failed";
                }
            }
            else
            {
                message = "Failed";
            }

            var model = new CourseSaveViewModel();
            model.DepartmentSelectListItems = departmentDAL.GetAll()
                                                .Select(c => new SelectListItem()
                                                {
                                                    Value = c.Id.ToString(),
                                                    Text = c.DepartmentName
                                                });     
            ViewBag.EMessage = message;
            return View(model);
        }

        ////----------------Save Course End---------------/////
        ////----------------Save Teacher---------------/////

        [HttpGet]
        public ActionResult SaveTeacher()
        {
            var model = new TeacherSaveViewModel();
            model.DepartmentSelectListItems = departmentDAL.GetAll()
                                                .Select(c => new SelectListItem()
                                                {
                                                    Value = c.Id.ToString(),
                                                    Text = c.DepartmentName
                                                });

            return View(model);
        }
        [HttpPost]
        public ActionResult SaveTeacher(Teacher teacher)
        {
            var Fmessage = "";

            if (ModelState.IsValid)
            {             

                bool isSavedT = courseTeacherManager.Add(teacher);
                if (isSavedT)
                {
                    ViewBag.TMessage = "Teacher Information Saved Successfully!";
                }
                else
                {
                    Fmessage = "Teacher Information Saved Failed";
                }
            }
            else
            {
                Fmessage = "Failed";
            }

            var model = new TeacherSaveViewModel();
            model.DepartmentSelectListItems = departmentDAL.GetAll()
                                                .Select(c => new SelectListItem()
                                                {
                                                    Value = c.Id.ToString(),
                                                    Text = c.DepartmentName
                                                });
            ViewBag.FMessage = Fmessage;
            return View(model);
        }

        ////----------------Save Teacher End---------------/////
        ////----------------Save Asing Teacher ---------------/////
        CoueseTeacherDAL courseTeacherDAL = new CoueseTeacherDAL();

        [HttpGet]
        public ActionResult AssignTeacher()
        {
            var model = new AssignTeacherViewModel();
            model.DepartmentSelectListItems2 = courseTeacherDAL.TeacherGetAll().Select(c => new SelectListItem() { Value = c.DepartmentId.ToString(), Text = c.Department.DepartmentName });
            model.CoursetSelectListItems = courseTeacherDAL.CourseGetAll().Select(c => new SelectListItem() { Value = c.CourseId.ToString(), Text = c.CourseCode });
            //model.EmployeeList = _repository.GetAll();
            model.TeachertSelectListItems = GetDefaultSelectListItem();
            model.TeachertInfoListItems = GetTDefaultSelectListItem();
            //model.EmployeeEducationSelectListItems = GetDefaultSelectListItem();
            return View(model);
        }

        private IEnumerable<SelectListItem> GetDefaultSelectListItem()
        {
            return new List<SelectListItem> { new SelectListItem { Value = "", Text = "Select..." } };
        }
        private IEnumerable<SelectListItem> GetTDefaultSelectListItem()
        {
            return new List<SelectListItem> { new SelectListItem { Value = "", Text = "View..." } };
        }
        public JsonResult GetTeacherByDepartmentId(int departmentId)
        {
            //var dataList = _repository.Get(c=>c.DepartmentId==departmentId).Tolist();
            var dataList = courseTeacherDAL.TeacherGetAll();
            dataList = dataList.Where(c => c.DepartmentId == departmentId).ToList();
            var jsonData = dataList.Select(c => new { c.TeacherId, c.TeacherName });
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTeacherInfoByTeacherId(int teacherTd)
        {
            var dataList = courseTeacherDAL.TeacherGetAll().Where(c => c.TeacherId == teacherTd).ToList();
            var jsonData = dataList.Select(c => new { c.CreditTaken });
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourseCourseId(int courseId)
        {
            var dataList = courseTeacherDAL.CourseGetAll().Where(c => c.CourseId == courseId).ToList();
            var jsonData = dataList.Select(c => new { c.CourseId, c.CourseCode, c.CourseCredit, c.CourseName });
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AssignTeacher(AssignTeacher assignTeacher)
        {
            var message = "";

            if (ModelState.IsValid)
            {
                //var course = Mapper.Map<Course>(model);

                bool isSaved = courseTeacherManager.Add(assignTeacher);
                if (isSaved)
                {
                    ViewBag.SMessage = "Assign Teacher Successfully!";
                }
                else
                {
                    message = "Assign Teacher Saved Failed";
                }
            }
            else
            {
                message = "Failed";
            }

            var model = new AssignTeacherViewModel();
            model.DepartmentSelectListItems2 = courseTeacherDAL.TeacherGetAll().Select(c => new SelectListItem() { Value = c.DepartmentId.ToString(), Text = c.Department.DepartmentName });
            model.CoursetSelectListItems = courseTeacherDAL.CourseGetAll().Select(c => new SelectListItem() { Value = c.CourseId.ToString(), Text = c.CourseCode });
            model.TeachertSelectListItems = GetDefaultSelectListItem();
            model.TeachertInfoListItems = GetTDefaultSelectListItem();
            ViewBag.EMessage = message;
            return View(model);
 
        }




        //private IEnumerable<SelectListItem> GetDefaultSelectListItem()
        //{
        //    return new List<SelectListItem> { new SelectListItem { Value = "", Text = "---Select---" } };
        //}


        //[HttpPost]
        //public ActionResult Create(EmployeeCreateViewModel model)
        //{
        //    var msg = "Failed";
        //    if (ModelState.IsValid)
        //    {

        //        var employee = Mapper.Map<Employee>(model);

        //        bool isAdded = _repository.Add(employee);
        //        if (isAdded)
        //        {
        //            ViewBag.SMsg = "Saved";

        //        }
        //        else
        //        {
        //            ViewBag.EMsg = "Failed"; ;
        //        }
        //    }
        //    else
        //    {
        //        msg = AppUtility.GetModelStateError(ModelState);
        //        ViewBag.EMsg = msg;
        //    }
        //    model.DepartmentSelectListItems = _departmentRepository.GetAll()
        //                                        .Select(c => new SelectListItem()
        //                                        {
        //                                            Value = c.Id.ToString(),
        //                                            Text = c.Name
        //                                        });
        //    model.EmployeeList = _repository.GetAll();

        //    return View(model);
        //}


        ////----------------Save Asing Teacher End---------------/////



    }
}
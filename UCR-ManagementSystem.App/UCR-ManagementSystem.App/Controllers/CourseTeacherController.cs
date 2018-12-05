using System;
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
                //var course = Mapper.Map<Course>(model);

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



    }
}
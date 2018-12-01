using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCR_ManagementSystem.BLL.BLL;
using UCR_ManagementSystem.Models;

using UCR_ManagementSystem.Models.Models;
using UCR_ManagementSystem.DAL.DAL;

namespace UCR_ManagementSystem.App.Controllers
{
    public class CourseTeacherController : Controller
    {
        //
        // GET: /CourseTeacher/



        CourseTeacherManager courseTeacherManager = new CourseTeacherManager();

        [HttpGet]
        public ActionResult SaveCourse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveCourse(Course course)
        {
            var message = "";

            if (ModelState.IsValid)
            {
                bool isSaved = courseTeacherManager.Add(course);
                if (isSaved)
                {
                    ViewBag.SMessage = "Department Information Saved Successfully!";

                    return View();
                }
                else
                {
                    message = "Department Information Saved Failed";
                }
            }
            else
            {
                message = "Failed";
            }
            ViewBag.EMessage = message;
            return View();
        }
	}
}
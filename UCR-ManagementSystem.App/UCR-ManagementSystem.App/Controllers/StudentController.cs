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
        DepartmentDAL departmentDAL = new DepartmentDAL();
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
    }
    ////----------------Save Student End---------------/////
}
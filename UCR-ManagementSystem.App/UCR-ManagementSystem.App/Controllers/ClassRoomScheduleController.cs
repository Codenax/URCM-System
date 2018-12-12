using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCR_ManagementSystem.App.Models;
using UCR_ManagementSystem.BLL.BLL;
using UCR_ManagementSystem.DAL.DAL;
using UCR_ManagementSystem.Models.Models;

namespace UCR_ManagementSystem.App.Controllers
{
    public class ClassRoomScheduleController : Controller
    {
        //
        // GET: /ClassRoomSchedule/

        ClassRoomScheduleManager classRoomScheduleManager = new ClassRoomScheduleManager();
        CoueseTeacherDAL courseTeacherDAL = new CoueseTeacherDAL();

        ///---------------------------Allocate Class Room----------------------------------///
        
        [HttpGet]
        public ActionResult allocateClassrooms()
        {
            var model = new ClassroomScheduleViewModel();
            model.DepartmentSelectListItems = courseTeacherDAL.CourseGetAll()
                                                .Select(c => new SelectListItem() 
                                                {
                                                    Value = c.DepartmentId.ToString(),
                                                    Text = c.Department.DepartmentName
                                                });
            model.CoursetSelectListItems = GetDefaultSelectListItem();
            return View(model);
        }

        private IEnumerable<SelectListItem> GetDefaultSelectListItem()
        {
            return new List<SelectListItem> { new SelectListItem { Value = "", Text = "Select..." } };
        }
        public JsonResult GetCourseByDepartmentId(int departmentId)
        {

            var dataList = courseTeacherDAL.CourseGetAll().Where(c => c.DepartmentId == departmentId).ToList();
            var jsonData = dataList.Select(c => new { c.CourseId, c.CourseName});
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult allocateClassrooms(AllocateClassRoom allocateClassRoom)
        {
            var message = "";

            if (ModelState.IsValid)
            {
                bool isSaved = classRoomScheduleManager.Add(allocateClassRoom);
                if (isSaved)
                {
                    ViewBag.SACMessage = "Class Schedule Information Saved Successfully!";
                }
                else
                {
                    message = "Class Schedule Information Saved Failed";
                }
            }
            else
            {
                message = "Failed";
            }
            var model = new ClassroomScheduleViewModel();
            model.DepartmentSelectListItems = courseTeacherDAL.CourseGetAll()
                                                .Select(c => new SelectListItem()
                                                {
                                                    Value = c.DepartmentId.ToString(),
                                                    Text = c.Department.DepartmentName
                                                });
            model.CoursetSelectListItems = GetDefaultSelectListItem();     
            ViewBag.FACMessage = message;
            return View(model);
        }
        ///---------------------------Allocate Class Room End----------------------------------///


	}
}
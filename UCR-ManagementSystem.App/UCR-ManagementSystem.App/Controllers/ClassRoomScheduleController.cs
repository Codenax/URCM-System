using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCR_ManagementSystem.App.Models;
using UCR_ManagementSystem.BLL.BLL;
using UCR_ManagementSystem.DAL.DAL;
using UCR_ManagementSystem.Models.Models;

using System.Threading.Tasks;
using System.Globalization;
using System.Data.Entity.Core.Objects;

namespace UCR_ManagementSystem.App.Controllers
{
    public class ClassRoomScheduleController : Controller
    {
        //
        // GET: /ClassRoomSchedule/

        ClassRoomScheduleManager classRoomScheduleManager = new ClassRoomScheduleManager();
        CoueseTeacherDAL courseTeacherDAL = new CoueseTeacherDAL();
        ClassRoomScheduleDAL classRoomScheduleDAL = new ClassRoomScheduleDAL();

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
        ///---------------------------viewCourseSchedule----------------------------------///

        [HttpGet]
        public ActionResult viewCourseSchedule()
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

        public JsonResult viewCourseScheduleByDepartmentId(int departmentId)
        {

            var Result = classRoomScheduleDAL.AllocateClassRoomGetAll().Select(n => new
            {
                CourseId = n.CourseId,
                RomNo = n.RoomNo,
                Day = n.Day,
                ToTime = n.ToTime,
                FromTime = n.FromTime,
                Schedule = n.RoomNo + ",   " + n.Day + ",   " + new DateTime(n.FromTime.Ticks).ToString("%h:mm tt") + " - " + new DateTime(n.ToTime.Ticks).ToString("%h:mm tt") + ";",
            });
            var newResult = (from a in Result.ToList()
                             group a by a.CourseId into CourseGroup
                             select new
                             {
                                 CourseId = CourseGroup.FirstOrDefault().CourseId,
                                 Schedule = String.Join( "\n" , (CourseGroup.Select(x => x.Schedule)).ToArray())
                             });
            var ResultFinal = from s in courseTeacherDAL.CourseGetAll()
                        join c in newResult
                        on s.CourseId equals c.CourseId into sGroup
                        from c in sGroup.DefaultIfEmpty()
                        //where s.DepartmentId == departmentId
                        select new
                        {
                            DepartmentId = s.DepartmentId,
                            CourseCode = s.CourseCode,
                            CourseName = s.CourseName,               
                            Schedule = c == null ? "Not Scheduled Yet" : c.Schedule,
                        };
            var dataList = ResultFinal.Where(c => c.DepartmentId == departmentId).ToList();
            var jsonData = dataList.Select(c => new { c.CourseCode, c.CourseName, c.Schedule});
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }



        ///---------------------------viewCourseSchedule end----------------------------------///


	}
}
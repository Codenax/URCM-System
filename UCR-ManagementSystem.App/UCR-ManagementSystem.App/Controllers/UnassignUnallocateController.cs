using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCR_ManagementSystem.DAL.DAL;
using UCR_ManagementSystem.Models.Models;
using UCR_ManagementSystem.BLL.BLL;
using UCR_ManagementSystem.Models;
using System.Data.Entity;
using UCR_ManagementSystem.App.Models;
using AutoMapper;

namespace UCR_ManagementSystem.App.Controllers
{
    public class UnassignUnallocateController : Controller
    {
        private readonly ClassRoomScheduleDAL classRoomSechudelDAL;
        private readonly CoueseTeacherDAL coueseTeacherDAL;
        public UnassignUnallocateController()
        {
            classRoomSechudelDAL = new ClassRoomScheduleDAL();
            coueseTeacherDAL = new CoueseTeacherDAL();

        }

        [HttpGet]
        public ActionResult UnassignCourses()
        {

            return View();
        }

        [HttpPost]
        public ActionResult UnassignCourses(AssignTeacher assignTeacher)
        {

            var unAssigns = coueseTeacherDAL.AssingTeacherGetAll();
            foreach (var item in unAssigns)
            {
                item.IsUnassign = true;
            }
            coueseTeacherDAL.Complete();
            ViewBag.SMessage = "Unassign Courses Successfully!";
            return View();
        }

        [HttpGet]
        public ActionResult UnallocateClassroom()
        {
            return View();
        }


        [HttpPost]
        public ActionResult UnallocateClassroom(AllocateClassRoom allocateClassRoom)
        {
            var allocates = classRoomSechudelDAL.AllocateClassRoomGetAll();
            foreach (var item in allocates)
            {
                item.IsUnallocate = true;
            }
            classRoomSechudelDAL.Complete();
            ViewBag.SMessage = "Unallocate Classroom Successfully!";
            return View();
        }
	}
}

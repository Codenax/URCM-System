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
namespace UCR_ManagementSystem.App.Controllers
{
    public class DepartmentController : Controller
    {
        //
        
        // GET: /Department/

       
       DepartmentManager departmentManager = new DepartmentManager();

        [HttpGet]
       public ActionResult SaveDepartment()
        {
           
            return View();
           
        }


        [HttpPost]
        public ActionResult SaveDepartment(Department department)
        {

                   if (ModelState.IsValid)
                   {
                       bool isSaved = departmentManager.Add(department);
                       if (isSaved)
                       {
                           
                           ViewBag.SMessage = "Department Information Saved Successfully!";
                           ModelState.Clear();
                           
                       }
                       else
                       {
                           ViewBag.EMessage = "Name or Code Information Already Exists";
                           return View();
                       }
                   }
                   else
                   {
                       ViewBag.EMessage = "Information Saved Failed";
                   }
    
          
           ModelState.Clear();
           return View();

        }
        DepartmentDAL departmentDAL = new DepartmentDAL();
        public ActionResult ShowDepartment()
        {
            var model = new Department();
            model.DepartmentList = departmentDAL.GetAll();
            return View(model);
        }
    }
}

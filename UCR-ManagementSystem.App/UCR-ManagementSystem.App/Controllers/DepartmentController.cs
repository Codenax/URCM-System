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
            var message = "";
           // string dName= department.Name;
           // int dCode=department.Code;
           // var model = new Department();
           // model.DepartmentList = departmentDAL.GetAll();
           // foreach (var departmentv in model.DepartmentList)
           // {
           //     dName = departmentv.Name;
           //    dCode = departmentv.Code;
           // }
            
           //if( dCode == department.Code)
           //{
           //    message = "Department Code Allready Have";
           //}
           //else
           //{
           //    if (dName == department.Name)
           //    {
           //        message = " Department Name Allready Have";
           //    }
           //    else
           //    {
                   if (ModelState.IsValid)
                   {
                       bool isSaved = departmentManager.Add(department);
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
           //    }             

           //}
            //if (ModelState.IsValid)
            //{


            //    bool isSaved = departmentManager.Add(department);
            //    if (isSaved)
            //    {
            //        ViewBag.SMessage = "Department Information Saved Successfully!";
                  
            //        return View();
            //    }
            //    else
            //    {
            //        message = "Department Information Saved Failed";
            //    }
            //}
            //else
            //{
            //    message = "Failed";
            //}

           ViewBag.EMessage = message;
           return View();


        }
        DepartmentDAL departmentDAL = new DepartmentDAL();
        public ActionResult ShowDepartment()
        {
            var model = new Department();
            model.DepartmentList = departmentDAL.GetAll();
            return View(model);
        }











            //string message = "<h1> Welcome to Employee Create Page </h1>";
            //message += "<br />";
            //DepartmentManager departmentManager = new DepartmentManager();
            //bool isSaved = departmentManager.Add(department);
            //if (isSaved)
            //{
            //    message += "<p> Name: " + department.Code + "</p>";
            //    message += "<p> Address: " + department.Name + "</p>";             
            //}
            //else
            //{
            //    message += "No Employee Saved";
            //}
            //return message;
    }
}

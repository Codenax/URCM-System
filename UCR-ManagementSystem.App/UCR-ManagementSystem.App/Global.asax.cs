using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using UCR_ManagementSystem.App.Models;
using UCR_ManagementSystem.Models.Models;
namespace UCR_ManagementSystem.App
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<CourseSaveViewModel, Course>();
                    cfg.CreateMap<Course, CourseSaveViewModel>();
                });
        }
    }
}

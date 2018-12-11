using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UCR_ManagementSystem.App
{
    public class AppUtility
    {
        public static string GetModelStateError(ModelStateDictionary modelState)
        {
            return string.Join(" | ", modelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
        }
    }
}
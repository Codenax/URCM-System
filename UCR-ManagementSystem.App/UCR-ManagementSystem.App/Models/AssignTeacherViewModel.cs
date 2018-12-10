using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UCR_ManagementSystem.App.Models
{
    public class AssignTeacherViewModel
    {


        public int TeacherId { get; set; }
        public double CreditTaken { get; set; }
        public double RemainingCredit { get; set; }
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public double CourseCredit { get; set; }
        public int DepartmentId { get; set; }
        public IEnumerable<SelectListItem> DepartmentSelectListItems2 { get; set; }
        public IEnumerable<SelectListItem> TeachertSelectListItems { get; set; }
        public IEnumerable<SelectListItem> TeachertInfoListItems { get; set; }
        public IEnumerable<SelectListItem> CoursetSelectListItems { get; set; }

    }
}
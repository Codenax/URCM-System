using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCR_ManagementSystem.Models.Models;

namespace UCR_ManagementSystem.App.Models
{
    public class AssignTeacherViewModel
    {


        [Required(ErrorMessage = "Teacher Is Required")]
        [Display(Name = "Teacher")]
        public int TeacherId { get; set; }

        //[Required(ErrorMessage = "Credit Is Required")]
        [Display(Name = "Credit to be Taken")]
        public double CreditTaken { get; set; }

        //[Required(ErrorMessage = "Remaining Credit Is Required")]
        [Display(Name = "Remaining Credit")]
        public double RemainingCredit { get; set; }
        [Required(ErrorMessage = "Course Code Is Required")]
        [Display(Name = "Course Code")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Course Code Is Required")]
        [Display(Name = "Course Code")]
        public string CourseCode { get; set; }
        //[Required(ErrorMessage = "Course Code Is Required")]
        [Display(Name = "Name")]
        public string CourseName { get; set; }
        [Required(ErrorMessage = "Course Code Is Required")]
        [Display(Name = "Course Code")]
        public string Semester { get; set; }
        [Required(ErrorMessage = "Course Code Is Required")]
        [Display(Name = "Course Code")]
        public string AssignTo { get; set; }
        //[Required(ErrorMessage = "Course Code Is Required")]
        [Display(Name = "Credit")]
        public double AssignCourseCredit { get; set; }

        [Required(ErrorMessage = "Department Is Required")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public IEnumerable<SelectListItem> DepartmentSelectListItems2 { get; set; }
        public IEnumerable<SelectListItem> TeachertSelectListItems { get; set; }
        public IEnumerable<SelectListItem> TeachertInfoListItems { get; set; }
        public IEnumerable<SelectListItem> CoursetSelectListItems { get; set; }
        public IEnumerable<SelectListItem> DepartmentSelectListItemsViewCourseStatics { get; set; }

    }
}
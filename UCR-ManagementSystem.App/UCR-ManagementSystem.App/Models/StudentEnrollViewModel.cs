using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UCR_ManagementSystem.App.Models
{
    public class StudentEnrollViewModel
    {

        [Required(ErrorMessage = "Reg.No Is Required")]
        [Display(Name = "Student Reg.No")]
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Name Is Required")]
        [Display(Name = "Name")]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "Email Is Required")]
        [Display(Name = "Email ")]
        [EmailAddress(ErrorMessage = "Provide a Valid Email Address")]
        public string StudentEmail { get; set; }

        [Required(ErrorMessage = "Department Is Required")]
        [Display(Name = "Department")]
        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "Course Is Required")]
        [Display(Name = "Select Course ")]
        public int CourseId { get; set; }


        [Display(Name = "Data")]
        public DateTime EnrollData { get; set; }

        public IEnumerable<SelectListItem> RegistrationNumberList { get; set; }

        public IEnumerable<SelectListItem> CoursetSelectListItems { get; set; }

        public IEnumerable<SelectListItem> DepartmentSelectListItems { get; set; }
    }
}
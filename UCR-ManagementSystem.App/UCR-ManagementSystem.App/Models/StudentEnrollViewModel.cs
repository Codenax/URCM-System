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
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Student Name Is Required")]
        [Display(Name = "Student Name")]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "Email Is Required")]
        [Display(Name = "Email ")]
        [EmailAddress(ErrorMessage = "Provide a Valid Email Address")]
        public string StudentEmail { get; set; }
        public string DepartmentName { get; set; }
        public int CourseId { get; set; }


        [Display(Name = "Data")]
        public DateTime EnrollData { get; set; }

        public IEnumerable<SelectListItem> RegistrationNumberList { get; set; }

        public IEnumerable<SelectListItem> CoursetSelectListItems { get; set; }

        public IEnumerable<SelectListItem> DepartmentSelectListItems { get; set; }
    }
}
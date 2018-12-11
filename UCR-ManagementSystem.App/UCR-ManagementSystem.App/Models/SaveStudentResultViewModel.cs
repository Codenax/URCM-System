using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UCR_ManagementSystem.App.Models
{
    public class SaveStudentResultViewModel
    {
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Student Name Is Required")]
        [Display(Name = "Student Name")]
        public string StudentName { get; set; }

        [Display(Name = "Email ")]
        public string StudentEmail { get; set; }
        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "Course Is Required")]
        [Display(Name = "Select Course")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Grade LetteIs Required")]
        [Display(Name = "Select Grade Letter")]
        public string GradeLetter { get; set; }
        public IEnumerable<SelectListItem> RegistrationNumberList { get; set; }

        public IEnumerable<SelectListItem> CoursetSelectListItems { get; set; }

    }
}
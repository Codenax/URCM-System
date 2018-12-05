using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UCR_ManagementSystem.Models.Models;

namespace UCR_ManagementSystem.App.Models
{
    public class CourseSaveViewModel
    {

        [Required(ErrorMessage = "Course Code Is Required")]
        [Display(Name = "Course Code")]
        [StringLength(20,MinimumLength = 5, ErrorMessage = "Course Code  must  be  at  least  five  (5)  characters  long.")]
        public int CourseCode { get; set; }

        [Required(ErrorMessage = "Course Name Is Required")]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Credit Is Required")]
        [Display(Name = "Credit")]   
        [Range(0.5, 5, ErrorMessage = "Credit Range is from 0.5 to 5.0")]
        public double CourseCredit { get; set; }
        [Required(ErrorMessage = "Description Is Required")]
        [Display(Name = "Description")]
        public string CourseDescription { get; set; }

        [Required(ErrorMessage = "Department Name Is Required")]
        [Display(Name = "Department Name")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Semeste Is Required")]
        [Display(Name = "Semester")]
        public int Semester { get; set; }


        public List<Course> CourseList { get; set; }
        public IEnumerable<SelectListItem> DepartmentSelectListItems { get; set; }
         
    }
}
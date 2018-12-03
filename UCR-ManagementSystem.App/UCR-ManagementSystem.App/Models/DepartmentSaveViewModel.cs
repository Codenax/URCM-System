using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UCR_ManagementSystem.App.Models
{
    public class DepartmentSaveViewModel
    {
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Department Code Is Required")]
        [StringLength(7, MinimumLength = 2, ErrorMessage = "Department Code must be a minimum and maximum length between 2 and 7 characters.")]
        [Display(Name = "Department Code")]
        public int DepartmentCode { get; set; }


        [Required(ErrorMessage = "Department Name Is Required")]
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
    }
}
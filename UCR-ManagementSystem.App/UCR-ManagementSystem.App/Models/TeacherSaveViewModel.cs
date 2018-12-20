using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UCR_ManagementSystem.App.Models
{
    public class TeacherSaveViewModel
    {
        [Required(ErrorMessage = "Name Is Required")]
        [Display(Name = "Name")]
        public string TeacherName { get; set; }

        [Required(ErrorMessage = "Address Is Required")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Email Is Required")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Provide a Valid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Contact No Is Required")]
        [Display(Name = "Contact No.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Contact No must be 11 characters")]
        public long ContactNo { get; set; }

        [Required(ErrorMessage = "Designation Is Required")]
        [Display(Name = "Designation")]
        public string Designation { get; set; }

        [Required(ErrorMessage = "Department Is Required")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Credit Is Required")]
        [Display(Name = "Credit to be taken")]
        [Range(1, 10000, ErrorMessage = "Input Non-negative Value")]
        public double CreditTaken { get; set; }

        public IEnumerable<SelectListItem> DepartmentSelectListItems { get; set; }

    }
}
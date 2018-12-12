using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UCR_ManagementSystem.App.Models
{
    public class ClassroomScheduleViewModel
    {

        [Required(ErrorMessage = "Department Is Required")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Course Is Required")]
        [Display(Name = "Course")]
        public int CourseId { get; set; }


        //[Display(Name = "Data")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime ScheduleData { get; set; }

        [Required(ErrorMessage = "Room No Is Required")]
        [Display(Name = "Room No")]
        public string RoomNo { get; set; }

        [Required(ErrorMessage = "Day Is Required")]
        [Display(Name = "Day")]
        public string Day { get; set; }

        [Required(ErrorMessage = "From Time Is Required")]
        [Display(Name = "From")]
        [DataType(DataType.Time)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public TimeSpan FromTime { get; set; }

        [Required(ErrorMessage = "To Time Is Required")]
        [Display(Name = "To")]
        [DataType(DataType.Time)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public TimeSpan ToTime { get; set; }

        public IEnumerable<SelectListItem> CoursetSelectListItems { get; set; }
        public IEnumerable<SelectListItem> DepartmentSelectListItems { get; set; }

    }
}
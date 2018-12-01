using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCR_ManagementSystem.Models.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public int CourseCode { get; set; }
        public string CourseName { get; set; }
        public int CourseCredit { get; set; }
        public string CourseDescription { get; set; }
        public string DepartmentName { get; set; }
        public int Semester { get; set; }

        [NotMapped]
        public List<Course> CourseList { get; set; }
    }
    
}

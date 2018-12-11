using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCR_ManagementSystem.Models.Models
{
    public class StudentEnroll
    {
        [Key]
        public int StudentEnrollId { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string DepartmentName { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrollData { get; set; }
        public Student Student { get; set; }
        //public Course Course { get; set; }
        //[NotMapped]
        //public List<StudentEnroll> StudentEnrollList { get; set; }
    }
}

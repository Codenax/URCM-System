using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCR_ManagementSystem.Models.Models
{
    public class SaveStudentResult
    {
        [Key]
        public int SaveStudentResultId { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string DepartmentName { get; set; }
        public int CourseId { get; set; }
        public string GradeLetter { get; set; }
        public Student Student { get; set; }
    }
}

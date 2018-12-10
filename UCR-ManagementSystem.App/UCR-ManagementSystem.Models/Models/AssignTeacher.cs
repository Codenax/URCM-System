using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCR_ManagementSystem.Models.Models
{
   public class AssignTeacher
    {

        [Key]
        public int AssignTeacherId { get; set; }
        public int TeacherId { get; set; }
        public double CreditTaken { get; set; }
        public double RemainingCredit{ get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public double CourseCredit { get; set; }
        public int DepartmentId { get; set; }
        public Teacher Teacher { get; set; }
        //[NotMapped]
        //public static List<AssignTeacher> GetAllAssignTeacherList();

        //[NotMapped]
        
    }    
}

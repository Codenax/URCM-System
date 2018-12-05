using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UCR_ManagementSystem.Models.Models
{
   public class Teacher
    {
        [Key]
        public int Id { get; set; }
        public string TeacherName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string ComtactNo { get; set; }
        public string Designation { get; set; }
        public int DepartmentId { get; set; }
        public double CreditTaken { get; set; }
    }
}

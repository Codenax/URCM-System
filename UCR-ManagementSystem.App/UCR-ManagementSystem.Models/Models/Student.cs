using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCR_ManagementSystem.Models.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
     
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public long StudentContactNo { get; set; }
        public DateTime RegData { get; set; }
        public string StudentAddress { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public string RegistrationNumber
        {
            get
            {
                return DepartmentId + " " + RegData;
            }
            set { }
        }
        [NotMapped]
        public List<Student> StudentList { get; set; }
    }
}


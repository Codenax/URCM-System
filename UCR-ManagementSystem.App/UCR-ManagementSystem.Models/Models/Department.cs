using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace UCR_ManagementSystem.Models.Models
{
    public class Department

    {
        [Key]
        public int Id { get; set; }
        public int DepartmentCode { get; set; }
        public string DepartmentName { get; set; }

        public virtual List<Course> Courses { get; set; }

        [NotMapped]
        public List<Department> DepartmentList { get; set; }

    }
}

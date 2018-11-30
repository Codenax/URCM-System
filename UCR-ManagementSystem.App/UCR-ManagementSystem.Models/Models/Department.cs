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

        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public List<Department> DepartmentList { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCR_ManagementSystem.Models.Models
{
   public class AllocateClassRoom
    {
        [Key]
        public int AllocateClassRoomId { get; set; }
        public int DepartmentId { get; set; }
        public int CourseId { get; set; }
        public string RoomNo { get; set; }
        public string Day { get; set; }

        [Column(TypeName = "time")]
        public TimeSpan FromTime { get; set; }

      
        [Column(TypeName = "time")]
        public TimeSpan ToTime { get; set; }
        public Course Course { get; set; }
    }
}

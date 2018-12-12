using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCR_ManagementSystem.DAL.DAL;
using UCR_ManagementSystem.Models.Models;

namespace UCR_ManagementSystem.BLL.BLL
{
   public class ClassRoomScheduleManager
    {
       ClassRoomScheduleDAL classRoomScheduleDAL = new ClassRoomScheduleDAL();

       ///----allocateClassRoom----///
       public bool Add(AllocateClassRoom allocateClassRoom)
        {
            bool isSaved = classRoomScheduleDAL.Add(allocateClassRoom);
            return isSaved;
        }

        ///----allocateClassRoom end----///

    }
}

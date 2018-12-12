using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCR_ManagementSystem.DatabaseContexts.DatabaseContext;
using UCR_ManagementSystem.Models.Models;
using System.Data.Entity;

namespace UCR_ManagementSystem.DAL.DAL
{
   public class ClassRoomScheduleDAL
    {
       UCRMSystemDbContext db = new UCRMSystemDbContext();
       ///----allocateClassRoom----///
       public bool Add(AllocateClassRoom allocateClassRoom)
       {
           db.AllocateClassRooms.Add(allocateClassRoom);

           return db.SaveChanges() > 0;
       }

       public List<AllocateClassRoom> AllocateClassRoomGetAll()
       {
           return db.AllocateClassRooms.Include(c => c.Course).ToList();
       }
        ///----allocateClassRoom end----///
    }
}

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
           if (AllocateClassRoomGetAll().Where(c => !c.IsUnallocate && c.RoomNo == allocateClassRoom.RoomNo && c.Day == allocateClassRoom.Day
               && (c.FromTime>= allocateClassRoom.FromTime && c.FromTime< allocateClassRoom.ToTime || c.ToTime> allocateClassRoom.FromTime && c.ToTime<= allocateClassRoom.FromTime)).Any())
           {

               return false;
           }

           else
           {
               db.AllocateClassRooms.Add(allocateClassRoom);
               return db.SaveChanges() > 0;
           }              

       }

       public List<AllocateClassRoom> AllocateClassRoomGetAll()
       {
           return db.AllocateClassRooms.Where(c => !c.IsUnallocate).Include(c => c.Course).ToList();
       }
        ///----allocateClassRoom end----///
       public int Complete()
       {         
           return db.SaveChanges();
       }
    }
}

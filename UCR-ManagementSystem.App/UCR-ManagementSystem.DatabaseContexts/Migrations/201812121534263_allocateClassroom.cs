namespace UCR_ManagementSystem.DatabaseContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allocateClassroom : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AllocateClassRooms",
                c => new
                    {
                        AllocateClassRoomId = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        RoomNo = c.String(),
                        Day = c.String(),
                        FromTime = c.DateTime(nullable: false),
                        ToTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AllocateClassRoomId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AllocateClassRooms", "CourseId", "dbo.Courses");
            DropIndex("dbo.AllocateClassRooms", new[] { "CourseId" });
            DropTable("dbo.AllocateClassRooms");
        }
    }
}

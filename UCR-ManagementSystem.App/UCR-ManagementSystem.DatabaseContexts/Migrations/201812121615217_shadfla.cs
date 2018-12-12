namespace UCR_ManagementSystem.DatabaseContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shadfla : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AllocateClassRooms", "FromTime", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Students", "RegData", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.StudentEnrolls", "EnrollData", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StudentEnrolls", "EnrollData", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Students", "RegData", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AllocateClassRooms", "FromTime", c => c.DateTime(nullable: false));
        }
    }
}

namespace UCR_ManagementSystem.DatabaseContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ljsdaf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AllocateClassRooms", "ToTime", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AllocateClassRooms", "ToTime");
        }
    }
}

namespace UCR_ManagementSystem.DatabaseContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asjdfhas : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AllocateClassRooms", "ToTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AllocateClassRooms", "ToTime", c => c.DateTime(nullable: false, storeType: "date"));
        }
    }
}

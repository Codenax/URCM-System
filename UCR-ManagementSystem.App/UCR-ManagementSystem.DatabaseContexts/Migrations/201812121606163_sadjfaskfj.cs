namespace UCR_ManagementSystem.DatabaseContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sadjfaskfj : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AllocateClassRooms", "ToTime", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AllocateClassRooms", "ToTime", c => c.DateTime(nullable: false));
        }
    }
}

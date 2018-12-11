namespace UCR_ManagementSystem.DatabaseContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ahkfla : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.StudentEnrolls", "EnrollData");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentEnrolls", "EnrollData", c => c.DateTime(nullable: false));
        }
    }
}

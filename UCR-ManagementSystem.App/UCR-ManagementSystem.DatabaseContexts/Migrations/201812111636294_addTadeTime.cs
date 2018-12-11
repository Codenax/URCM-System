namespace UCR_ManagementSystem.DatabaseContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTadeTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentEnrolls", "EnrollData", c => c.DateTime(nullable: false));
            DropColumn("dbo.StudentEnrolls", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentEnrolls", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.StudentEnrolls", "EnrollData");
        }
    }
}

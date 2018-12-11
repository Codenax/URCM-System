namespace UCR_ManagementSystem.DatabaseContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajfa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentEnrolls", "DepartmentName", c => c.String());
            AddColumn("dbo.StudentEnrolls", "EnrollData", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudentEnrolls", "EnrollData");
            DropColumn("dbo.StudentEnrolls", "DepartmentName");
        }
    }
}

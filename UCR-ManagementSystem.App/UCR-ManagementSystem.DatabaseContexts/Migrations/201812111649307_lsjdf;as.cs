namespace UCR_ManagementSystem.DatabaseContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lsjdfas : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.StudentEnrolls", "DepartmentName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentEnrolls", "DepartmentName", c => c.Int(nullable: false));
        }
    }
}

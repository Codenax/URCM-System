namespace UCR_ManagementSystem.DatabaseContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class caditChange : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Courses", "CourseCredit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "CourseCredit", c => c.Int(nullable: false));
        }
    }
}

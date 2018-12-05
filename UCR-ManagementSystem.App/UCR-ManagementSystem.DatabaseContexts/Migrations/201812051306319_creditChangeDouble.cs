namespace UCR_ManagementSystem.DatabaseContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creditChangeDouble : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "CourseCredit", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "CourseCredit");
        }
    }
}

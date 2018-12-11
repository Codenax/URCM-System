namespace UCR_ManagementSystem.DatabaseContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ksahdfla : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.StudentEnrolls", "StudentAddress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentEnrolls", "StudentAddress", c => c.String());
        }
    }
}

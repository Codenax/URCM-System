namespace UCR_ManagementSystem.DatabaseContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdfasfa : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Students");
            AddColumn("dbo.Students", "RegistrationNumber", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Students", "StudentId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Students", "StudentId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Students");
            AlterColumn("dbo.Students", "StudentId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Students", "RegistrationNumber");
            AddPrimaryKey("dbo.Students", "StudentId");
        }
    }
}

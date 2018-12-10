namespace UCR_ManagementSystem.DatabaseContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fsdfas : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Students");
            AlterColumn("dbo.Students", "StudentId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Students", "RegistrationNumber", c => c.String());
            AddPrimaryKey("dbo.Students", "StudentId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Students");
            AlterColumn("dbo.Students", "RegistrationNumber", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Students", "StudentId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Students", "StudentId");
        }
    }
}

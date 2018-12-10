namespace UCR_ManagementSystem.DatabaseContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdsfa : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "RegistrationNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "RegistrationNumber", c => c.String());
        }
    }
}

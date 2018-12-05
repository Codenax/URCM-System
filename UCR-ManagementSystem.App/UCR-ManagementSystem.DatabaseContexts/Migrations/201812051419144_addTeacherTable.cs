namespace UCR_ManagementSystem.DatabaseContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTeacherTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherName = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        ComtactNo = c.String(),
                        Designation = c.String(),
                        DepartmentId = c.Int(nullable: false),
                        CreditTaken = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Teachers");
        }
    }
}

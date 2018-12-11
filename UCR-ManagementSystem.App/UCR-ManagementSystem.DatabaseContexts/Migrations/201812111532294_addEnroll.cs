namespace UCR_ManagementSystem.DatabaseContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEnroll : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentEnrolls",
                c => new
                    {
                        StudentEnrollId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        StudentName = c.String(),
                        StudentEmail = c.String(),
                        DepartmentName = c.Int(nullable: false),
                        StudentAddress = c.String(),
                        CourseId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.StudentEnrollId)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentEnrolls", "StudentId", "dbo.Students");
            DropIndex("dbo.StudentEnrolls", new[] { "StudentId" });
            DropTable("dbo.StudentEnrolls");
        }
    }
}

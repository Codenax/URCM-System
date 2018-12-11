namespace UCR_ManagementSystem.DatabaseContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStudentResultTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SaveStudentResults",
                c => new
                    {
                        SaveStudentResultId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        StudentName = c.String(),
                        StudentEmail = c.String(),
                        DepartmentName = c.String(),
                        CourseId = c.Int(nullable: false),
                        GradeLetter = c.String(),
                    })
                .PrimaryKey(t => t.SaveStudentResultId)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaveStudentResults", "StudentId", "dbo.Students");
            DropIndex("dbo.SaveStudentResults", new[] { "StudentId" });
            DropTable("dbo.SaveStudentResults");
        }
    }
}

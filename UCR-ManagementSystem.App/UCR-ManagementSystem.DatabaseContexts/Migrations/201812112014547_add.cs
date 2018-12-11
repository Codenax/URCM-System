namespace UCR_ManagementSystem.DatabaseContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SaveStudentResults", "StudentId", "dbo.Students");
            DropIndex("dbo.SaveStudentResults", new[] { "StudentId" });
            AddColumn("dbo.SaveStudentResults", "StudentEnroll_StudentEnrollId", c => c.Int());
            CreateIndex("dbo.SaveStudentResults", "StudentEnroll_StudentEnrollId");
            AddForeignKey("dbo.SaveStudentResults", "StudentEnroll_StudentEnrollId", "dbo.StudentEnrolls", "StudentEnrollId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaveStudentResults", "StudentEnroll_StudentEnrollId", "dbo.StudentEnrolls");
            DropIndex("dbo.SaveStudentResults", new[] { "StudentEnroll_StudentEnrollId" });
            DropColumn("dbo.SaveStudentResults", "StudentEnroll_StudentEnrollId");
            CreateIndex("dbo.SaveStudentResults", "StudentId");
            AddForeignKey("dbo.SaveStudentResults", "StudentId", "dbo.Students", "StudentId", cascadeDelete: true);
        }
    }
}

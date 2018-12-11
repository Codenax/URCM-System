namespace UCR_ManagementSystem.DatabaseContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asfasfkj : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SaveStudentResults", "StudentEnroll_StudentEnrollId", "dbo.StudentEnrolls");
            DropIndex("dbo.SaveStudentResults", new[] { "StudentEnroll_StudentEnrollId" });
            CreateIndex("dbo.SaveStudentResults", "StudentId");
            AddForeignKey("dbo.SaveStudentResults", "StudentId", "dbo.Students", "StudentId", cascadeDelete: true);
            DropColumn("dbo.SaveStudentResults", "StudentEnroll_StudentEnrollId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SaveStudentResults", "StudentEnroll_StudentEnrollId", c => c.Int());
            DropForeignKey("dbo.SaveStudentResults", "StudentId", "dbo.Students");
            DropIndex("dbo.SaveStudentResults", new[] { "StudentId" });
            CreateIndex("dbo.SaveStudentResults", "StudentEnroll_StudentEnrollId");
            AddForeignKey("dbo.SaveStudentResults", "StudentEnroll_StudentEnrollId", "dbo.StudentEnrolls", "StudentEnrollId");
        }
    }
}

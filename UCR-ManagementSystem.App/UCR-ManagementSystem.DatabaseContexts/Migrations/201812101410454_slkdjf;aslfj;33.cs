namespace UCR_ManagementSystem.DatabaseContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class slkdjfaslfj33 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Teachers", "AssignTeacher_AssignTeacherId", "dbo.AssignTeachers");
            DropIndex("dbo.Teachers", new[] { "AssignTeacher_AssignTeacherId" });
            AddColumn("dbo.AssignTeachers", "AssignCourseCredit", c => c.Double(nullable: false));
            CreateIndex("dbo.AssignTeachers", "TeacherId");
            AddForeignKey("dbo.AssignTeachers", "TeacherId", "dbo.Teachers", "TeacherId", cascadeDelete: true);
            DropColumn("dbo.AssignTeachers", "RemainingCredit");
            DropColumn("dbo.AssignTeachers", "CourseCredit");
            DropColumn("dbo.Teachers", "AssignTeacher_AssignTeacherId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "AssignTeacher_AssignTeacherId", c => c.Int());
            AddColumn("dbo.AssignTeachers", "CourseCredit", c => c.Double(nullable: false));
            AddColumn("dbo.AssignTeachers", "RemainingCredit", c => c.Double(nullable: false));
            DropForeignKey("dbo.AssignTeachers", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.AssignTeachers", new[] { "TeacherId" });
            DropColumn("dbo.AssignTeachers", "AssignCourseCredit");
            CreateIndex("dbo.Teachers", "AssignTeacher_AssignTeacherId");
            AddForeignKey("dbo.Teachers", "AssignTeacher_AssignTeacherId", "dbo.AssignTeachers", "AssignTeacherId");
        }
    }
}

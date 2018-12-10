namespace UCR_ManagementSystem.DatabaseContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adslfja : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AssignTeachers", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.AssignTeachers", new[] { "TeacherId" });
            AddColumn("dbo.Teachers", "AssignTeacher_AssignTeacherId", c => c.Int());
            CreateIndex("dbo.Teachers", "AssignTeacher_AssignTeacherId");
            AddForeignKey("dbo.Teachers", "AssignTeacher_AssignTeacherId", "dbo.AssignTeachers", "AssignTeacherId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "AssignTeacher_AssignTeacherId", "dbo.AssignTeachers");
            DropIndex("dbo.Teachers", new[] { "AssignTeacher_AssignTeacherId" });
            DropColumn("dbo.Teachers", "AssignTeacher_AssignTeacherId");
            CreateIndex("dbo.AssignTeachers", "TeacherId");
            AddForeignKey("dbo.AssignTeachers", "TeacherId", "dbo.Teachers", "TeacherId", cascadeDelete: true);
        }
    }
}

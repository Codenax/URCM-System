namespace UCR_ManagementSystem.DatabaseContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssignTeachers",
                c => new
                    {
                        AssignTeacherId = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        CreditTaken = c.Double(nullable: false),
                        RemainingCredit = c.Double(nullable: false),
                        CourseId = c.Int(nullable: false),
                        CourseName = c.String(),
                        CourseCredit = c.Double(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AssignTeacherId)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        TeacherName = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        ContactNo = c.Long(nullable: false),
                        Designation = c.String(),
                        DepartmentId = c.Int(nullable: false),
                        CreditTaken = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentCode = c.String(),
                        DepartmentName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseCode = c.String(),
                        CourseName = c.String(),
                        CourseCredit = c.Double(nullable: false),
                        CourseDescription = c.String(),
                        Semester = c.String(),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentName = c.String(),
                        StudentEmail = c.String(),
                        StudentContactNo = c.Long(nullable: false),
                        RegData = c.DateTime(nullable: false),
                        StudentAddress = c.String(),
                        DepartmentId = c.Int(nullable: false),
                        RegistrationNumber = c.String(),
                    })
                .PrimaryKey(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssignTeachers", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Courses", new[] { "DepartmentId" });
            DropIndex("dbo.Teachers", new[] { "DepartmentId" });
            DropIndex("dbo.AssignTeachers", new[] { "TeacherId" });
            DropTable("dbo.Students");
            DropTable("dbo.Courses");
            DropTable("dbo.Departments");
            DropTable("dbo.Teachers");
            DropTable("dbo.AssignTeachers");
        }
    }
}

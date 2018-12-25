namespace UCR_ManagementSystem.DatabaseContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AllocateClassRooms",
                c => new
                    {
                        AllocateClassRoomId = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        RoomNo = c.String(),
                        Day = c.String(),
                        FromTime = c.Time(nullable: false, precision: 7),
                        ToTime = c.Time(nullable: false, precision: 7),
                        IsUnallocate = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AllocateClassRoomId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
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
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentCode = c.String(),
                        DepartmentName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AssignTeachers",
                c => new
                    {
                        AssignTeacherId = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        CreditTaken = c.Double(nullable: false),
                        CourseId = c.Int(nullable: false),
                        CourseName = c.String(),
                        AssignCourseCredit = c.Double(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        IsUnassign = c.Boolean(nullable: false),
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
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentName = c.String(),
                        StudentEmail = c.String(),
                        StudentContactNo = c.Long(nullable: false),
                        RegData = c.DateTime(nullable: false, storeType: "date"),
                        StudentAddress = c.String(),
                        DepartmentId = c.Int(nullable: false),
                        RegistrationNumber = c.String(),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.StudentEnrolls",
                c => new
                    {
                        StudentEnrollId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        StudentName = c.String(),
                        StudentEmail = c.String(),
                        DepartmentName = c.String(),
                        CourseId = c.Int(nullable: false),
                        EnrollData = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.StudentEnrollId)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentEnrolls", "StudentId", "dbo.Students");
            DropForeignKey("dbo.SaveStudentResults", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.AssignTeachers", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.AllocateClassRooms", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.StudentEnrolls", new[] { "StudentId" });
            DropIndex("dbo.Students", new[] { "DepartmentId" });
            DropIndex("dbo.SaveStudentResults", new[] { "StudentId" });
            DropIndex("dbo.Teachers", new[] { "DepartmentId" });
            DropIndex("dbo.AssignTeachers", new[] { "TeacherId" });
            DropIndex("dbo.Courses", new[] { "DepartmentId" });
            DropIndex("dbo.AllocateClassRooms", new[] { "CourseId" });
            DropTable("dbo.StudentEnrolls");
            DropTable("dbo.Students");
            DropTable("dbo.SaveStudentResults");
            DropTable("dbo.Teachers");
            DropTable("dbo.AssignTeachers");
            DropTable("dbo.Departments");
            DropTable("dbo.Courses");
            DropTable("dbo.AllocateClassRooms");
        }
    }
}

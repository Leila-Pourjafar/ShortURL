namespace ShortURLService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class student : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Course", newName: "Courses");
            RenameTable(name: "dbo.Enrollment", newName: "Enrollments");
            RenameTable(name: "dbo.Student", newName: "Students");
            RenameTable(name: "dbo.URL", newName: "URLs");
            RenameTable(name: "dbo.UrlStat", newName: "UrlStats");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.UrlStats", newName: "UrlStat");
            RenameTable(name: "dbo.URLs", newName: "URL");
            RenameTable(name: "dbo.Students", newName: "Student");
            RenameTable(name: "dbo.Enrollments", newName: "Enrollment");
            RenameTable(name: "dbo.Courses", newName: "Course");
        }
    }
}

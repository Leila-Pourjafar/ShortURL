using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShortURLService.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace ShortURLService.DAL
{
    public class UrlContext : DbContext
    {
        public DbSet<URL> Urls { get; set; }
        public DbSet<UrlStat> UrlStats { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public UrlContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<UrlContext, Migrations.Configuration>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Course>()
            .HasMany(c => c.Instructors).WithMany(i => i.Courses)
            .Map(t => t.MapLeftKey("CourseID")
                .MapRightKey("InstructorID")
                .ToTable("CourseInstructor"));
            modelBuilder.Entity<Instructor>()
               .HasOptional(p => p.OfficeAssignment).WithRequired(p => p.Instructor);

            base.OnModelCreating(modelBuilder);


        }
    }


}
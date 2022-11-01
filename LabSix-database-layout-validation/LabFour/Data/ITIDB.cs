using LabFour.Models;
using Microsoft.EntityFrameworkCore;

namespace LabFour.Data
{
    public class ITIDB:DbContext
    {
        public ITIDB()
        {

        }

        public ITIDB(DbContextOptions options):base(options)
        {

        }
        public DbSet<Student> Students { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<StudentCourses> StudentCourses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=LabFour;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<StudentCourses>().HasKey(a => new { a.stdId, a.CrsId });
            modelBuilder.Entity<Course>().HasKey(a => a.CrsId);
            modelBuilder.Entity<Course>().Property(a => a.CrsName).IsRequired()
                .HasMaxLength(10);
    
            base.OnModelCreating(modelBuilder);    
                
        }
    }
}

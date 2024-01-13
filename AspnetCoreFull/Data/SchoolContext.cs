using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AspnetCoreFull.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AspnetCoreFull.Data
{
    public class SchoolContext : IdentityDbContext<ApplicationUser>
    {
        public SchoolContext (DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          modelBuilder.Entity<Course>().ToTable("Course");
          modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
          modelBuilder.Entity<Student>().ToTable("Student");
        }


        public DbSet<User>? User { get; set; }
        public DbSet<Gender>? Gender { get; set; }
        public DbSet<AnimalType>? AnimalType { get; set; }
        public DbSet<AnimalProgressType>? AnimalProgressType { get; set; }
        public DbSet<AnimalProgress>? AnimalProgress { get; set; }
        public DbSet<AnimalMedicalHistory>? AnimalMedicalHistory { get; set; }
        public DbSet<AnimalMedicalCondtionType>? AnimalMedicalCondtionType { get; set; }
        public DbSet<Animal>? Animal { get; set; }
        public DbSet<AgriSectorType>? AgriSectorType { get; set; }
    }
}

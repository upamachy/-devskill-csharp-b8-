using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    class ManyToManyContext:DbContext
    {
        private readonly string _connectionString;
        private readonly string _assemblyName;
        public ManyToManyContext()
        {
            _connectionString = ConnectionStringReader.ConnectionString;
            _assemblyName = typeof(Program).Assembly.FullName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_assemblyName));
            }

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>()
                .HasKey(a => new { a.CourseId, a.StudentId });


            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.CourseId);

            modelBuilder.Entity<Enrollment>()
               .HasOne(e => e.Student)
               .WithMany(s => s.Enrollments)
               .HasForeignKey(e => e.StudentId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

    }
}

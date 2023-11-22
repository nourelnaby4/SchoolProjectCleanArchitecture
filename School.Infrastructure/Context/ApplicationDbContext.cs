using Microsoft.EntityFrameworkCore;
using School.Data.Entities;
using System.Reflection;

namespace School.Infrastructure.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Student> students { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<DepartmentSubject> departmentSubjects { get; set; }
        public DbSet<StudentSubject> studentSubjects { get; set; }
        public DbSet<Instructor> instructors { get; set; }
        public DbSet<InstructorSubject> instructorSubjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // apply Entities Configurations
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Data.Entities;

namespace School.Infrastructure.Configurations
{
    public class DepartmentSubjectConfig : IEntityTypeConfiguration<DepartmentSubject>
    {
        public void Configure(EntityTypeBuilder<DepartmentSubject> modelBuilder)
        {
            modelBuilder.HasKey(e => new { e.SubjectId, e.DepartmentId });

            modelBuilder.HasOne(ds => ds.Department)
                  .WithMany(d => d.DepartmentsSubjects)
                  .HasForeignKey(ds => ds.DepartmentId);

            modelBuilder.HasOne(ds => ds.Subject)
                 .WithMany(d => d.DepartmentsSubjects)
                 .HasForeignKey(ds => ds.SubjectId);
        }
    }
}

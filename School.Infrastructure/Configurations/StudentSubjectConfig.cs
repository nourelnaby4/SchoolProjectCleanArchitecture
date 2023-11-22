using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Data.Entities;

namespace School.Infrastructure.Configurations
{
    public class StudentSubjectConfig : IEntityTypeConfiguration<StudentSubject>
    {
        public void Configure(EntityTypeBuilder<StudentSubject> modelBuilder)
        {
            modelBuilder.HasKey(e => new { e.SubjectId, e.StudentId });
        }
    }
}

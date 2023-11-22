using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Data.Entities;

namespace School.Infrastructure.Configurations
{
    public class InstructorSubjectConfig : IEntityTypeConfiguration<InstructorSubject>
    {
        public void Configure(EntityTypeBuilder<InstructorSubject> modelBuilder)
        {
            modelBuilder.HasKey(e => new { e.SubjectId, e.InstructorId });
        }
    }
}

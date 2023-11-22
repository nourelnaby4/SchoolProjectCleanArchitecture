using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Data.Entities;
using System.Reflection.Emit;

namespace School.Infrastructure.Configurations
{
    public class InstructorConfig : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> modelBuilder)
        {
            modelBuilder.HasOne(e => e.Suprvisor)
                .WithMany(e => e.Instructors)
                .OnDelete(DeleteBehavior.Restrict); 

        }
    }
}

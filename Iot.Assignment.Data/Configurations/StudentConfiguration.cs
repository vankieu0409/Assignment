using Iot.Assignment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Iot.Assignment.Data.Configurations;

public class StudentConfiguration :IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("STUDENT");
        builder.HasKey(c => c.Id);
        builder.HasOne<Classes>(c=>c.Classes)
            .WithMany(c=>c.StudentCollection)
            .HasForeignKey(c=>c.ClassId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany<Subjects>(c=>c.SubjectCollection)
            .WithOne(c=>c.Student)
            .HasForeignKey(c=>c.StudentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
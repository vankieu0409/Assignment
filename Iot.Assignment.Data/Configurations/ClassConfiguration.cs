using Iot.Assignment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Iot.Assignment.Data.Configurations;

public class ClassConfiguration: IEntityTypeConfiguration<Classes>
{
    public void Configure(EntityTypeBuilder<Classes> builder)
    {
        builder.ToTable("CLASS");
        builder.HasKey(entity => entity.Id);
        builder.HasOne<Majors>(entity => entity.Majors)
            .WithMany(entity => entity.ClassesCollection)
            .HasForeignKey(entity => entity.MajorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
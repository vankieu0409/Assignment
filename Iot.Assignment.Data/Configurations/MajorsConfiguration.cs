using Iot.Assignment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Iot.Assignment.Data.Configurations;

public class MajorsConfiguration:IEntityTypeConfiguration<Majors>
{
    public void Configure(EntityTypeBuilder<Majors> builder)
    {
        builder.ToTable("MAJOR");
        builder.HasKey(e => e.Id);
        builder.HasOne<University>(p => p.Universities)
            .WithMany(p => p.MajorsCollection)
            .HasForeignKey(entity => entity.UniversityId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
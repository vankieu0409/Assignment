using Iot.Assignment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Iot.Assignment.Data.Configurations;

public class UniversityConfiguration:IEntityTypeConfiguration<University>
{
    public void Configure(EntityTypeBuilder<University> builder)
    {
        builder.ToTable("University");
        builder.HasKey(entity => entity.Id);
    }
}
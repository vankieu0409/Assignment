using Iot.Assignment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Iot.Assignment.Data.Configurations;

public class SubjectConfiguration : IEntityTypeConfiguration<Subjects>
{
    public void Configure(EntityTypeBuilder<Subjects> builder)
    {
        builder.ToTable("SUBJECT");
        builder.HasKey(entity => entity.Id);
        //builder.ha
    }
}
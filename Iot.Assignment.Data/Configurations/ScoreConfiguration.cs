using Iot.Assignment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Iot.Assignment.Data.Configurations;

public class ScoreConfiguration:IEntityTypeConfiguration<Scores>
{
    public void Configure(EntityTypeBuilder<Scores> builder)
    {
        builder.ToTable("SCORE");
        builder.HasKey(c => c.Id);
    }
}
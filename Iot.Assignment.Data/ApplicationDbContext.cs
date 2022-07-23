using System.Diagnostics.CodeAnalysis;
using System.Threading.Channels;
using Microsoft.EntityFrameworkCore;
using Iot.Assignment.Domain;
using Iot.Assignment.Domain.Entities;

namespace Iot.Assignment.Data;

public class ApplicationDbContext : DbContext
{
    public virtual DbSet<University> Universities { get; set; }
    public virtual DbSet<Majors> Majors { get; set; }
    public virtual DbSet<Classes> Classes { get; set; }
    public virtual DbSet<Student> Students { get; set; }
    public ApplicationDbContext([NotNullAttribute] DbContextOptions options): base(options)
    {
        ChangeTracker.LazyLoadingEnabled = false;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.LogTo(Console.WriteLine);
    }
}
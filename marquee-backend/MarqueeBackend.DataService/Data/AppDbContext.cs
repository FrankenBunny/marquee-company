using dotnetFullstack.Entities.DbSet;
using Microsoft.EntityFrameworkCore;

namespace dotnetFullstack.DataService.Data;

public class AppDbContext : DbContext
{
    public virtual DbSet<Rentable> Rentables { get; set; }
    public virtual DbSet<Part> Parts { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Part>(entity =>
            {
                entity.HasOne(r => r.Rentable)
                .WithMany(p => p.Parts)
                .HasForeignKey(r => r.RentableId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Parts_Rentable");
            }
        );
    }
}
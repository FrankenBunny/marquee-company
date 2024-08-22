using MarqueeBackend.Entities.DbSet;
using Microsoft.EntityFrameworkCore;

namespace MarqueeBackend.DataService.Data;

public class AppDbContext : DbContext
{
    public virtual DbSet<Rentable> Rentables { get; set; }
    public virtual DbSet<Part> Parts { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Item> Items { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Part>(entity =>
        {
            entity
                .HasOne(r => r.Rentable)
                .WithMany(p => p.Parts)
                .HasForeignKey(r => r.RentableId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Parts_Rentable");
        });

        modelBuilder.Entity<Rentable>(entity =>
        {
            entity
                .HasOne(c => c.Category)
                .WithMany(r => r.Rentables)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Category_Rentable");
        });
    }
}

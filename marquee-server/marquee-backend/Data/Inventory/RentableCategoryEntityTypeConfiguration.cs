using marquee_backend.Models.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class RentableCategoryEntityTypeConfiguration : IEntityTypeConfiguration<RentableCategory>
{
    public void Configure(EntityTypeBuilder<RentableCategory> modelBuilder)
    {
      modelBuilder.ToTable("rentable_category");

      modelBuilder.HasIndex(e => e.Title, "unique_name").IsUnique();

      modelBuilder.Property(e => e.Id)
        .ValueGeneratedNever()
        .HasColumnName("id");

      modelBuilder.Property(e => e.Title)
        .HasMaxLength(30)
        .IsRequired(true)
        .HasColumnName("title");

      modelBuilder.Property(e => e.Description)
        .HasMaxLength(200)
        .IsRequired(true)
        .HasColumnName("description");
    }
}
using marquee_backend.Models.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PartEntityTypeConfiguration : IEntityTypeConfiguration<Part>
{
    public void Configure(EntityTypeBuilder<Part> modelBuilder)
    {
      modelBuilder.ToTable("part");

      modelBuilder.HasIndex(e => e.Title, "unique_name").IsUnique();

      modelBuilder.Property(e => e.Id)
        .ValueGeneratedNever()
        .HasColumnName("id");

      modelBuilder.Property(e => e.Title)
        .HasMaxLength(30)
        .IsRequired(true)
        .HasColumnName("title");

      modelBuilder.Property(e => e.Note)
        .HasMaxLength(100)
        .HasColumnName("note");

      modelBuilder.HasOne<Rentable>()
        .WithMany()
        .HasForeignKey(e => e.RentableId)
        .HasConstraintName("fk_part_rentable_id");

      modelBuilder.Property(e => e.RentableId)
        .HasColumnName("rentable_id")
        .IsRequired();
    }
}
using marquee_backend.Models.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class RentableTagRentableEntityTypeConfiguration
    : IEntityTypeConfiguration<RentableTagRentable>
{
    public void Configure(EntityTypeBuilder<RentableTagRentable> modelBuilder)
    {
        modelBuilder.ToTable("rentable_tag_rentable");

        modelBuilder.Property(e => e.Id).ValueGeneratedNever().HasColumnName("id");

        modelBuilder.Property(e => e.RentableTagId).HasColumnName("rentable_tag_id");
        modelBuilder.Property(e => e.RentableId).HasColumnName("rentable_id");

        modelBuilder
            .HasOne<RentableTag>()
            .WithMany()
            .HasForeignKey(d => d.RentableTagId)
            .HasConstraintName("FK_rentable_tag_id")
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder
            .HasOne<Rentable>()
            .WithMany()
            .HasForeignKey(d => d.RentableId)
            .HasConstraintName("fk_rentable_id")
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder
            .HasIndex(e => new { e.RentableTagId, e.RentableId })
            .IsUnique()
            .HasDatabaseName("IX_rentable_tag_rentable_unique");
    }
}

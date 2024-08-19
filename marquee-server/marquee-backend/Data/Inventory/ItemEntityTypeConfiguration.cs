using marquee_backend.Models.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ItemEntityTypeConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> modelBuilder)
    {
        modelBuilder.ToTable("item");

        modelBuilder.HasIndex(e => e.Title, "unique_name").IsUnique();

        modelBuilder.Property(e => e.Id).ValueGeneratedNever().HasColumnName("id");

        modelBuilder
            .Property(e => e.Title)
            .HasMaxLength(30)
            .IsRequired(true)
            .HasColumnName("title");

        modelBuilder.Property(e => e.Note).HasMaxLength(100).HasColumnName("note");
    }
}

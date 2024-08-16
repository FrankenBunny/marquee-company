using marquee_backend.Models.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class RoleEntityTypeConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> modelBuilder)
    {
      modelBuilder.ToTable("role");

      modelBuilder.HasIndex(e => e.Name, "unique_name").IsUnique();

      modelBuilder.Property(e => e.Id)
        .ValueGeneratedNever()
        .HasColumnName("id");
        
      modelBuilder.Property(e => e.Name)
        .HasMaxLength(30)
        .HasColumnName("name");
    }
}
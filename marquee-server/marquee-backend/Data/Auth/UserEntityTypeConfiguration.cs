using marquee_backend.Models.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> modelBuilder)
    {
        modelBuilder
          .ToTable("user");

        modelBuilder.HasIndex(e => e.Username, "unique_username").IsUnique();
        modelBuilder.HasIndex(e => e.Email, "unique_email").IsUnique();

        modelBuilder.Property(e => e.Id)
          .ValueGeneratedNever()
          .HasColumnName("id");

        modelBuilder.Property(e => e.Email)
          .HasMaxLength(256)
          .HasColumnName("email");
          

        modelBuilder.Property(e => e.Name)
          .HasMaxLength(50)
          .HasColumnName("name");

        modelBuilder.Property(e => e.PasswordHash).HasColumnName("password_hash");

        modelBuilder.Property(e => e.Username)
          .HasMaxLength(20)
          .HasColumnName("username");
    }
}
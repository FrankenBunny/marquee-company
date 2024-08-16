using marquee_backend.Models.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserRoleEntityTypeConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> modelBuilder)
    {
      modelBuilder
        .HasNoKey()
        .ToTable("user_role");

      modelBuilder.Property(e => e.RoleId).HasColumnName("role_id");
      modelBuilder.Property(e => e.UserId).HasColumnName("user_id");

      modelBuilder.HasOne(d => d.Role).WithMany()
        .HasForeignKey(d => d.RoleId)
        .HasConstraintName("FK_user_role_role_id");

      modelBuilder.HasOne(d => d.User).WithMany()
        .HasForeignKey(d => d.UserId)
        .HasConstraintName("fk_user_role_user_id");
    }
}
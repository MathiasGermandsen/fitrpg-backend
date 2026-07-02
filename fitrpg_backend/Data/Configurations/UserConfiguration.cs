using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using fitrpg_backend.Models;

namespace fitrpg_backend.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
  public void Configure(EntityTypeBuilder<User> b)
  {
    b.ToTable("users");
    b.HasKey(u => u.Id);
    b.Property(u => u.Username).IsRequired().HasMaxLength(50);
    b.Property(u => u.Email).IsRequired().HasMaxLength(100);
    b.HasIndex(u => u.Email).IsUnique();
    b.Property(u => u.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
  }
}

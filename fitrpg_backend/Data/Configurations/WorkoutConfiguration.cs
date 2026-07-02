using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using fitrpg_backend.Models;

namespace fitrpg_backend.Data.Configurations;

public class WorkoutConfiguration : IEntityTypeConfiguration<Workout>
{
  public void Configure(EntityTypeBuilder<Workout> b)
  {
    b.ToTable("workouts");
    b.HasKey(w => w.Id);
    b.Property(w => w.Type).IsRequired().HasMaxLength(50);
    b.Property(w => w.Notes).HasMaxLength(500);
    b.HasIndex(w => w.UserId);
    b.HasIndex(w => w.CreatedAt);
    b.Property(w => w.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

    b.HasOne(w => w.User)
     .WithMany(u => u.Workouts)
     .HasForeignKey(w => w.UserId)
     .OnDelete(DeleteBehavior.Cascade);
  }
}

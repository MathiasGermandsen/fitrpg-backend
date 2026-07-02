using Microsoft.EntityFrameworkCore;
using fitrpg_backend.Models;

namespace fitrpg_backend.Data;

public class WorkoutContext : DbContext
{
  public WorkoutContext(DbContextOptions<WorkoutContext> options) : base(options)
  {
  }

  public DbSet<User> Users => Set<User>();
  public DbSet<Workout> Workouts => Set<Workout>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(WorkoutContext).Assembly);
  }
}

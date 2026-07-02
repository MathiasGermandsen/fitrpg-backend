using Microsoft.EntityFrameworkCore;
using fitrpg_backend.Models;
using fitrpg_backend.Data.Repositories.Interfaces;

namespace fitrpg_backend.Data.Repositories;

public class WorkoutRepository : IWorkoutRepository
{
  private readonly WorkoutContext _db;

  public WorkoutRepository(WorkoutContext db) => _db = db;

  public async Task<Workout?> GetByIdAsync(int id)
      => await _db.Workouts.FindAsync(id);

  public async Task<IReadOnlyList<Workout>> GetForUserAsync(int userId)
      => await _db.Workouts
          .Where(w => w.UserId == userId)
          .OrderByDescending(w => w.CreatedAt)
          .ToListAsync();

  public async Task AddAsync(Workout workout)
  {
    await _db.Workouts.AddAsync(workout);
    await _db.SaveChangesAsync();
  }

  public async Task DeleteAsync(int id)
  {
    var workout = await _db.Workouts.FindAsync(id);
    if (workout != null)
    {
      _db.Workouts.Remove(workout);
      await _db.SaveChangesAsync();
    }
  }
}

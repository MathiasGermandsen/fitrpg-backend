using fitrpg_backend.Models;

namespace fitrpg_backend.Data.Repositories.Interfaces;

public interface IWorkoutRepository
{
  Task<Workout?> GetByIdAsync(int id);
  Task<IReadOnlyList<Workout>> GetForUserAsync(int userId);
  Task AddAsync(Workout workout);
  Task DeleteAsync(int id);
}

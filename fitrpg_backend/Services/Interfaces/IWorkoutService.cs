using fitrpg_backend.DTOs.Workouts;

namespace fitrpg_backend.Services.Interfaces;

public interface IWorkoutService
{
  Task<WorkoutDto> LogWorkoutAsync(CreateWorkoutDto dto);
  Task<WorkoutDto?> GetByIdAsync(int id);
  Task<IReadOnlyList<WorkoutDto>> GetForUserAsync(int userId);
}

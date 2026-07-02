using fitrpg_backend.Models;
using fitrpg_backend.DTOs.Workouts;
using fitrpg_backend.Services.Interfaces;
using fitrpg_backend.Data.Repositories.Interfaces;

namespace fitrpg_backend.Services;

public class WorkoutService : IWorkoutService
{
  private readonly IWorkoutRepository _workouts;
  private readonly IGamificationService _gamification;

  public WorkoutService(IWorkoutRepository workouts, IGamificationService gamification)
  {
    _workouts = workouts;
    _gamification = gamification;
  }

  public async Task<WorkoutDto> LogWorkoutAsync(CreateWorkoutDto dto)
  {
    var workout = new Workout
    {
      UserId = dto.UserId,
      Type = dto.Type,
      DurationMinutes = dto.DurationMinutes,
      Notes = dto.Notes,
      CreatedAt = DateTime.UtcNow
    };

    await _workouts.AddAsync(workout);

    // Basic XP logic: 10 XP per minute
    await _gamification.AwardXpAsync(workout.UserId, workout.DurationMinutes * 10);

    return MapToDto(workout);
  }

  public async Task<WorkoutDto?> GetByIdAsync(int id)
  {
    var workout = await _workouts.GetByIdAsync(id);
    return workout is null ? null : MapToDto(workout);
  }

  public async Task<IReadOnlyList<WorkoutDto>> GetForUserAsync(int userId)
  {
    var list = await _workouts.GetForUserAsync(userId);
    return list.Select(MapToDto).ToList();
  }

  private static WorkoutDto MapToDto(Workout w) => new(
      w.Id,
      w.UserId,
      w.Type,
      w.DurationMinutes,
      w.Notes,
      w.CreatedAt
  );
}

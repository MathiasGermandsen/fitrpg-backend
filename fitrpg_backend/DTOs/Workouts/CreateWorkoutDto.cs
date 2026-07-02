namespace fitrpg_backend.DTOs.Workouts;

public record CreateWorkoutDto(
    int UserId,
    string Type,
    int DurationMinutes,
    string? Notes
);

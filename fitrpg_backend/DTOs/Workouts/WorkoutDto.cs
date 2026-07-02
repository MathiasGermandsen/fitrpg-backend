namespace fitrpg_backend.DTOs.Workouts;

public record WorkoutDto(
    int Id,
    int UserId,
    string Type,
    int DurationMinutes,
    string? Notes,
    DateTime CreatedAt
);

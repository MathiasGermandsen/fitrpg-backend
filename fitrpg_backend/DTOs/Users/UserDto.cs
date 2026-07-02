namespace fitrpg_backend.DTOs.Users;

public record UserDto(
    int Id,
    string Username,
    string Email,
    int Xp,
    int Level,
    int Streak,
    DateTime CreatedAt
);

using fitrpg_backend.Models;
using fitrpg_backend.DTOs.Users;
using fitrpg_backend.Services.Interfaces;
using fitrpg_backend.Data.Repositories.Interfaces;

namespace fitrpg_backend.Services;

public class UserService : IUserService
{
  private readonly IUserRepository _users;

  public UserService(IUserRepository users) => _users = users;

  public async Task<UserDto?> GetByIdAsync(int id)
  {
    var user = await _users.GetByIdAsync(id);
    return user is null ? null : MapToDto(user);
  }

  public async Task<UserDto> CreateAsync(CreateUserDto dto)
  {
    var user = new User
    {
      Username = dto.Username,
      Email = dto.Email,
      CreatedAt = DateTime.UtcNow
    };

    await _users.AddAsync(user);
    return MapToDto(user);
  }

  private static UserDto MapToDto(User user) => new(
      user.Id,
      user.Username,
      user.Email,
      user.Xp,
      user.Level,
      user.Streak,
      user.CreatedAt
  );
}

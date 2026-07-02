using fitrpg_backend.DTOs.Users;

namespace fitrpg_backend.Services.Interfaces;

public interface IUserService
{
  Task<UserDto?> GetByIdAsync(int id);
  Task<UserDto> CreateAsync(CreateUserDto dto);
}

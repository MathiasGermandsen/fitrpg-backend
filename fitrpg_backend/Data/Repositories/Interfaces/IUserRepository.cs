using fitrpg_backend.Models;

namespace fitrpg_backend.Data.Repositories.Interfaces;

public interface IUserRepository
{
  Task<User?> GetByIdAsync(int id);
  Task<User?> GetByEmailAsync(string email);
  Task AddAsync(User user);
  Task UpdateAsync(User user);
}

using Microsoft.EntityFrameworkCore;
using fitrpg_backend.Models;
using fitrpg_backend.Data.Repositories.Interfaces;

namespace fitrpg_backend.Data.Repositories;

public class UserRepository : IUserRepository
{
  private readonly WorkoutContext _db;

  public UserRepository(WorkoutContext db) => _db = db;

  public async Task<User?> GetByIdAsync(int id)
      => await _db.Users.FindAsync(id);

  public async Task<User?> GetByEmailAsync(string email)
      => await _db.Users.FirstOrDefaultAsync(u => u.Email == email);

  public async Task AddAsync(User user)
  {
    await _db.Users.AddAsync(user);
    await _db.SaveChangesAsync();
  }

  public async Task UpdateAsync(User user)
  {
    _db.Users.Update(user);
    await _db.SaveChangesAsync();
  }
}

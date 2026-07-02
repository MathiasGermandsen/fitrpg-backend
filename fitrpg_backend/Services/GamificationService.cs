using fitrpg_backend.Models;
using fitrpg_backend.Services.Interfaces;
using fitrpg_backend.Data.Repositories.Interfaces;

namespace fitrpg_backend.Services;

public class GamificationService : IGamificationService
{
  private readonly IUserRepository _users;

  public GamificationService(IUserRepository users) => _users = users;

  public async Task AwardXpAsync(int userId, int xpAmount)
  {
    var user = await _users.GetByIdAsync(userId);
    if (user == null) return;

    user.Xp += xpAmount;

    // Simple level logic: every 1000 XP is a level
    int newLevel = (user.Xp / 1000) + 1;
    if (newLevel > user.Level)
    {
      user.Level = newLevel;
    }

    await _users.UpdateAsync(user);
  }
}

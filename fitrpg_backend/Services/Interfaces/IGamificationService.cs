using fitrpg_backend.Models;

namespace fitrpg_backend.Services.Interfaces;

public interface IGamificationService
{
  Task AwardXpAsync(int userId, int xpAmount);
}

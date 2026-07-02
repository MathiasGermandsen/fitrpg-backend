using System;

namespace fitrpg_backend.Models;

public class Workout
{
  public int Id { get; set; }
  public int UserId { get; set; }
  public string Type { get; set; } = string.Empty;
  public int DurationMinutes { get; set; }
  public string? Notes { get; set; }
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

  public User User { get; set; } = null!;
}

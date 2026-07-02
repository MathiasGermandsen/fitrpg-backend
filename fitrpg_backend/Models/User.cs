using System;
using System.Collections.Generic;

namespace fitrpg_backend.Models;

public class User
{
  public int Id { get; set; }
  public string Username { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public int Xp { get; set; }
  public int Level { get; set; } = 1;
  public int Streak { get; set; }
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

  public ICollection<Workout> Workouts { get; set; } = new List<Workout>();
}

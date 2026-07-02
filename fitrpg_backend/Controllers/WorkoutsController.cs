using Microsoft.AspNetCore.Mvc;
using fitrpg_backend.DTOs.Workouts;
using fitrpg_backend.Services.Interfaces;

namespace fitrpg_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkoutsController : ControllerBase
{
  private readonly IWorkoutService _workouts;

  public WorkoutsController(IWorkoutService workouts) => _workouts = workouts;

  [HttpPost]
  public async Task<ActionResult<WorkoutDto>> Create(CreateWorkoutDto dto)
  {
    var result = await _workouts.LogWorkoutAsync(dto);
    return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
  }

  [HttpGet("{id:int}")]
  public async Task<ActionResult<WorkoutDto>> GetById(int id)
  {
    var workout = await _workouts.GetByIdAsync(id);
    return workout is null ? NotFound() : Ok(workout);
  }

  [HttpGet("user/{userId:int}")]
  public async Task<ActionResult<IReadOnlyList<WorkoutDto>>> GetForUser(int userId)
      => Ok(await _workouts.GetForUserAsync(userId));
}

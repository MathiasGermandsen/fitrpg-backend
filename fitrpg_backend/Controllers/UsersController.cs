using Microsoft.AspNetCore.Mvc;
using fitrpg_backend.DTOs.Users;
using fitrpg_backend.Services.Interfaces;

namespace fitrpg_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
  private readonly IUserService _users;

  public UsersController(IUserService users) => _users = users;

  [HttpGet("{id:int}")]
  public async Task<ActionResult<UserDto>> GetById(int id)
  {
    var user = await _users.GetByIdAsync(id);
    return user is null ? NotFound() : Ok(user);
  }

  [HttpPost]
  public async Task<ActionResult<UserDto>> Create(CreateUserDto dto)
  {
    var result = await _users.CreateAsync(dto);
    return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
  }
}

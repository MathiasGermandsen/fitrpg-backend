using Microsoft.AspNetCore.Mvc;

namespace fitrpg_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
  [HttpGet]
  public IActionResult Check() => Ok(new { status = "Healthy" });
}

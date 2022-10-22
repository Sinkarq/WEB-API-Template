using Microsoft.AspNetCore.Mvc;

namespace YourProject.Server.Features;

[ApiController]
[Route("[controller]")]
public abstract class ApiController : ControllerBase
{
}

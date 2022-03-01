using Microsoft.AspNetCore.Mvc;

namespace YourProject.Server.Controllers.Base;

[ApiController]
[Route("[controller]")]
public abstract class ApiController : ControllerBase
{
}

using System.Security.Claims;
using YourProject.Server.Services.Interfaces;

namespace YourProject.Server.Services;

public class CurrentUser : ICurrentUser
{
    public CurrentUser(IHttpContextAccessor httpContextAccessor)
        => this.UserId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

    public string UserId { get; }
}
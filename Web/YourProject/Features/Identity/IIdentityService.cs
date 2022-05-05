namespace YourProject.Server.Features.Identity;

public interface IIdentityService
{
    string GenerateJwtToken(string userId,string username, string secret);
}
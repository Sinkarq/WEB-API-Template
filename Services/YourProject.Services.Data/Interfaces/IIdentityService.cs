namespace YourProject.Services.Data.Interfaces;

public interface IIdentityService
{
    string GenerateJwtToken(string userId,string username, string secret);
}
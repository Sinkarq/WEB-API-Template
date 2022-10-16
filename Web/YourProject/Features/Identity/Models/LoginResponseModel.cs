namespace YourProject.Server.Features.Identity.Models;

public class LoginResponseModel
{
    public LoginResponseModel(string token)
    {
        ArgumentNullException.ThrowIfNull(token);
        this.Token = token;
    }

    public string Token { get; private set; }
}
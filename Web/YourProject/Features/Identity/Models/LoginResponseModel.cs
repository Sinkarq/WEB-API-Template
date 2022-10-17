using YourProject.Common;

namespace YourProject.Server.Features.Identity.Models;

public class LoginResponseModel
{
    public LoginResponseModel(string token)
    {
        NullGuardMethods.Guard(token);
        this.Token = token;
    }

    public string Token { get; private set; }
}
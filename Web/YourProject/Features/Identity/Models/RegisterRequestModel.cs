using CommunityToolkit.Diagnostics;
using YourProject.Common;

namespace YourProject.Server.Features.Identity.Models;

public class RegisterRequestModel
{
    public RegisterRequestModel(string username, string password, string email)
    {
        NullGuardMethods.Guard(username, password, email);
        this.Username = username;
        this.Password = password;
        this.Email = email;
    }

    public string Username { get; private set; }
    
    public string Password { get; private set; }
    
    public string Email { get; private set; }
}

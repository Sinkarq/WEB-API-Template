using System.ComponentModel.DataAnnotations;
using YourProject.Common;

namespace YourProject.Server.Features.Identity.Models;
public class LoginRequestModel
{
    public LoginRequestModel(string userName, string password)
    {
        NullGuardMethods.Guard(userName, password);
        this.Username = userName;
        this.Password = password;
    }
    
    public string Username { get; private set; }
    
    public string Password { get; private set; }
}

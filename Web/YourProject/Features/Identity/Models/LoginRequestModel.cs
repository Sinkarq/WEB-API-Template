using System.ComponentModel.DataAnnotations;

namespace YourProject.Server.Features.Identity.Models;
public class LoginRequestModel
{
    public LoginRequestModel(string userName, string password)
    {
        ArgumentNullException.ThrowIfNull(userName);
        ArgumentNullException.ThrowIfNull(password);
        this.Username = userName;
        this.Password = password;
    }
    
    public string Username { get; private set; }
    
    public string Password { get; private set; }
}

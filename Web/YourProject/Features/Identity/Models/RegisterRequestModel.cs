namespace YourProject.Server.Features.Identity.Models;

public class RegisterRequestModel
{
    public RegisterRequestModel(string username, string password, string email)
    {
        ArgumentNullException.ThrowIfNull(username);
        ArgumentNullException.ThrowIfNull(password);
        ArgumentNullException.ThrowIfNull(email);
        this.Username = username;
        this.Password = password;
        this.Email = email;
    }

    public string Username { get; private set; }
    
    public string Password { get; private set; }
    
    public string Email { get; private set; }
}

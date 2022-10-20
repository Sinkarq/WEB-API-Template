using System.ComponentModel.DataAnnotations;
using YourProject.Common;

namespace YourProject.Server.Features.Identity.Models;
public class LoginRequestModel
{
    public string Username { get; set; }
    
    public string Password { get; set; }
}

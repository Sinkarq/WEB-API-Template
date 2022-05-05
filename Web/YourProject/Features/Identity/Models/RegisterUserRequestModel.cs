using System.ComponentModel.DataAnnotations;

namespace YourProject.Server.Features.Identity.Models;

public class RegisterUserRequestModel
{
    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public string Email { get; set; }
}

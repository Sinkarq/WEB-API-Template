using System.ComponentModel.DataAnnotations;

namespace YourProject.ViewModels.Identity;
public class LoginRequestModel
{
    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }
}

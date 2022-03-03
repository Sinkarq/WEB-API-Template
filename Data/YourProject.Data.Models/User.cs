using Microsoft.AspNetCore.Identity;

namespace YourProject.Data.Models;

public class User : IdentityUser
{
    public IEnumerable<Cat> Cats { get; set; } = new HashSet<Cat>();
}
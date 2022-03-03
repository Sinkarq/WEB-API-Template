using YourProject.Data.Common.Models;

namespace YourProject.Data.Models;

public class Cat : BaseDeletableModel<int>
{
    public string Name { get; set; }

    public string UserId { get; set; }

    public User User { get; set; }  
}
using YourProject.Data.Models;
using YourProject.Services.Mapping;

namespace YourProject.ViewModels;

public class Animal : IMapFrom<Cat>
{
    public string Name { get; set; }
}
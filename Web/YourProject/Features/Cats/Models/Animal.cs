using YourProject.Common;

namespace YourProject.Server.Features.Cats.Models;

public class Animal
{
    public Animal(string name)
    {
        NullGuardMethods.Guard(name);
        this.Name = name;
    }

    public string Name { get; private set; }
}
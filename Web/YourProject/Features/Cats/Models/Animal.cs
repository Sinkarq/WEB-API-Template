namespace YourProject.Server.Features.Cats.Models;

public class Animal
{
    public Animal(string name)
    {
        ArgumentNullException.ThrowIfNull(name);
        this.Name = name;
    }

    public string Name { get; private set; }
}
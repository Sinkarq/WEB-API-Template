﻿namespace YourProject.Data.Models;

public class Cat : BaseDeletableModel<int>
{
    public Cat(string name, string userId)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(userId);
        this.Name = name;
        this.UserId = userId;
    }

    // This is needed for EF Core to get the constructor
    // (It uses reflection under-the-hood so it will detect the private ctor)
    private Cat()
    {
        
    }

    public string Name { get; set; }

    public string UserId { get; set; }

    public User User { get; set; }  
}
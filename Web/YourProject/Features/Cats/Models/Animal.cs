﻿namespace YourProject.Server.Features.Cats.Models;

public class Animal : IMapFrom<Cat>
{
    public string Name { get; set; }
}
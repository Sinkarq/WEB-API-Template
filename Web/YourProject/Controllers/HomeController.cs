﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using YourProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using YourProject.Data.Common.Repositories;
using YourProject.Data.Models;
using YourProject.Infrastructure.Extensions;
using YourProject.Server.Controllers.Base;
using YourProject.Services.Mapping;

namespace YourProject.Server.Controllers;

public class HomeController : ApiController
{
    private readonly IDeletableEntityRepository<Cat> catsRepository;

    public HomeController(IDeletableEntityRepository<Cat> catsRepository)
    {
        this.catsRepository = catsRepository;
    }

    [HttpGet]
    [Authorize]
    [Route(nameof(GetFirstCatOfFirstUser))]
    public ActionResult<Animal> GetFirstCatOfFirstUser()
    {
        var userId = this.User.GetId();

        if (userId == null)
        {
            return new NotFoundResult();
        }
        
        return catsRepository
            .All()
            .Where(x => x.UserId == userId)
            .To<Animal>()
            .FirstOrDefault()!;
    }

    [HttpGet]
    [Route(nameof(GetById))]
    public ActionResult<Animal> GetById(int id)
    {
        return catsRepository
            .All()
            .Where(c => c.Id == id)
            .To<Animal>()
            .FirstOrDefault()
            .OrNotFound()!;

        // OrNotFound is a global action located in the Infrastructure Project
        // And all it does is this check
        // if (entity == null) return new NotFoundResult();
        // if not return the model
        // So it saves you everytime you have to check for
        // if you have null or valid entity that has been retrieved from the db
    }

    [HttpPost]
    [Authorize]
    [Route(nameof(CreateCat))]
    public async Task<ActionResult<List<Cat>>> CreateCat()
    {
        var userId = this.User.GetId();

        await catsRepository.AddAsync(new Cat {Name = "Sinan", UserId = userId});
        await catsRepository.SaveChangesAsync();

        return catsRepository.All().ToList();
    }
}
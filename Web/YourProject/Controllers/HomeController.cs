using YourProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using YourProject.Data.Common.Repositories;
using YourProject.Data.Models;
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
        
    [HttpPost]
    public async Task<ActionResult<List<Cat>>> Get()
    {
        await catsRepository.AddAsync(new Cat {Name = "Sinan"});
        await catsRepository.SaveChangesAsync();

        return catsRepository.All().ToList();
    }

    [HttpGet]
    public ActionResult<Animal> GetFirstCat()
    {
        return catsRepository.All().To<Animal>().FirstOrDefault()!;
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YourProject.Data.Common.Repositories;
using YourProject.Server.Features.Cats.Models;
using YourProject.Server.Infrastructure.Extensions;

namespace YourProject.Server.Features.Cats;

public class HomeController : ApiController
{
    private readonly IDeletableEntityRepository<Cat> catsRepository;
    private readonly ICatService catService;

    public HomeController(IDeletableEntityRepository<Cat> catsRepository, ICatService catService)
    {
        this.catsRepository = catsRepository;
        this.catService = catService;
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
    public IActionResult GetById(int id) => this.Ok(this.catService.GetById(id).OrNotFound());

    // OrNotFound is a global action located in the Infrastructure Project
    // And all it does is this check
    // if (entity == null) return new NotFoundResult();
    // if not return the model
    // So it saves you everytime you have to check for
    // if you have null or valid entity that has been retrieved from the db
    
    [HttpPost]
    [Authorize]
    [Route(nameof(CreateCat))]
    public async Task<IActionResult> CreateCat()
    {
        var userId = this.User.GetId();

        await catsRepository.AddAsync(new Cat {Name = "Sinan", UserId = userId});
        await catsRepository.SaveChangesAsync();

        return this.Ok(catsRepository.All().ToList());
    }
}
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YourProject.Data.Common.Repositories;
using YourProject.Server.Features.Cats.Models;
using YourProject.Server.Infrastructure.Extensions;

namespace YourProject.Server.Features.Cats;

public class CatsController : ApiController
{
    private readonly IDeletableEntityRepository<Cat> catsRepository;
    private readonly ICatService catService;
    private readonly IMapper mapper;

    public CatsController(IDeletableEntityRepository<Cat> catsRepository, ICatService catService, IMapper mapper)
    {
        this.catsRepository = catsRepository;
        this.catService = catService;
        this.mapper = mapper;
    }

    [HttpGet]
    [Route(nameof(GetById))]
    public async Task<IActionResult> GetById(int id)
    {
        var cat = await this.catService.GetById(id);
        var result = this.mapper.Map<Animal>(cat);

        return this.Ok(result);
    }

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

        await catsRepository.AddAsync(new Cat("Sinan", userId));
        await catsRepository.SaveChangesAsync();

        return this.Ok(catsRepository.All().ToList());
    }
}
using YourProject.Data.Common.Repositories;
using YourProject.Server.Features.Cats.Models;

namespace YourProject.Server.Features.Cats;

public class CatService : ICatService
{
    private readonly IDeletableEntityRepository<Cat> catsRepository;

    public CatService(IDeletableEntityRepository<Cat> catRepository) => this.catsRepository = catsRepository;

    public Animal GetById(int id) =>
        catsRepository
            .All()
            .Where(c => c.Id == id)
            .To<Animal>()
            .FirstOrDefault()!;
}
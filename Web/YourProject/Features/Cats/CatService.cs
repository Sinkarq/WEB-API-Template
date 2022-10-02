using YourProject.Data.Common.Repositories;
using YourProject.Server.Features.Cats.Models;

namespace YourProject.Server.Features.Cats;

internal sealed class CatService : ICatService
{
    private readonly IDeletableEntityRepository<Cat> catsRepository;

    public CatService(IDeletableEntityRepository<Cat> catRepository) => this.catsRepository = catRepository;

    public Animal GetById(int id) =>
        catsRepository
            .All()
            .Where(c => c.Id == id)
            .To<Animal>()
            .FirstOrDefault()!;
}
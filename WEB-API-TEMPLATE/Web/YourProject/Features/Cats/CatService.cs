using YourProject.Data.Common.Repositories;
using YourProject.Server.Features.Cats.Models;

namespace YourProject.Server.Features.Cats;

public sealed class CatService : ICatService
{
    private readonly IDeletableEntityRepository<Cat> catsRepository;

    public CatService(IDeletableEntityRepository<Cat> catRepository) => this.catsRepository = catRepository;

    public async Task<Cat> GetById(int id) =>
        (await catsRepository
            .Collection()
            .FindAsync(id))!;
}
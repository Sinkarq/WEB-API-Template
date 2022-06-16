using YourProject.Server.Features.Cats.Models;

namespace YourProject.Server.Features.Cats;

public interface ICatService : IService
{
    Animal GetById(int id);
}
namespace YourProject.Server.Features.Cats;

public interface ICatService
{
    Task<Cat> GetById(int id);
}
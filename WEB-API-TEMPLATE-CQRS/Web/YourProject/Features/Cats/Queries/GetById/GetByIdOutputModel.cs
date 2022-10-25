using YourProject.Server.Infrastructure.Mapping.Interfaces;

namespace YourProject.Server.Features.Cats.Queries.GetById;

public class GetByIdOutputModel
{
    public int Id { get; set; }
    
    public string Name { get; set; }
}
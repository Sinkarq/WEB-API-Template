using AutoMapper;
using MediatR;
using YourProject.Data.Common.Repositories;
using YourProject.Server.Infrastructure.Extensions;
using YourProject.Server.Infrastructure.Mapping.Interfaces;

namespace YourProject.Server.Features.Cats.Commands.CreateCommand;

public class CreateCommandModel : 
    IRequest<CreateCommandOutputModel>, 
    IMapTo<Cat>
{
    public string Name { get; set; }
    
    public class CreateCommandModelHandler : IRequestHandler<CreateCommandModel, CreateCommandOutputModel>
    {
        private readonly IDeletableEntityRepository<Cat> catRepository;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;

        public CreateCommandModelHandler(IMapper mapper, IDeletableEntityRepository<Cat> catRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.mapper = mapper;
            this.catRepository = catRepository;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<CreateCommandOutputModel> Handle(CreateCommandModel request, CancellationToken cancellationToken)
        {
            var cat = this.mapper.Map<Cat>(request);
            var userId = this.httpContextAccessor.HttpContext?.User.GetId();
            cat.UserId = userId!;

            await this.catRepository.AddAsync(cat);
            await this.catRepository.SaveChangesAsync();
            
            return this.mapper.Map<CreateCommandOutputModel>(cat);
        }
    }
}
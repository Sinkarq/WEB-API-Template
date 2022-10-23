using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using YourProject.Data.Common.Repositories;
using YourProject.Server.Infrastructure;
using YourProject.Server.Infrastructure.Extensions;
using YourProject.Server.Infrastructure.Mapping.Interfaces;

namespace YourProject.Server.Features.Cats.Commands.CreateCommand;

public class CreateCommandModel : 
    IRequest<FeatureResult<CreateCommandOutputModel>>, 
    IMapTo<Cat>
{
    public string Name { get; set; }
    
    public class CreateCommandModelHandler : IRequestHandler<CreateCommandModel, FeatureResult<CreateCommandOutputModel>>
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

        public async Task<FeatureResult<CreateCommandOutputModel>> Handle(CreateCommandModel request, CancellationToken cancellationToken)
        {
            var cat = this.mapper.Map<Cat>(request);
            var userId = this.httpContextAccessor.HttpContext?.User.GetId();
            cat.UserId = userId!;

            await this.catRepository.AddAsync(cat);
            await this.catRepository.SaveChangesAsync();

            if (cat.Id == 0)
            {
                return new FeatureResult<CreateCommandOutputModel>(new BadRequestResult());
            }
            
            var outputModel = this.mapper.Map<FeatureResult<CreateCommandOutputModel>>(cat);

            return new FeatureResult<CreateCommandOutputModel>(new OkObjectResult(outputModel));
        }
    }
}
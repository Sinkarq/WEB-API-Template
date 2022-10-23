using System.Collections;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using YourProject.Data.Common.Repositories;
using YourProject.Server.Infrastructure;

namespace YourProject.Server.Features.Cats.Queries.GetById;

public class GetByIdQueryModel : 
    IRequest<FeatureResult<GetByIdOutputModel>>
{
    public int Id { get; set; }
    
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQueryModel, FeatureResult<GetByIdOutputModel>>
    {
        private readonly IDeletableEntityRepository<Cat> catRepository;
        private readonly IMapper mapper;

        public GetByIdQueryHandler(IDeletableEntityRepository<Cat> catRepository, IMapper mapper)
        {
            this.catRepository = catRepository;
            this.mapper = mapper;
        }

        public async Task<FeatureResult<GetByIdOutputModel>> Handle(GetByIdQueryModel request, CancellationToken cancellationToken)
        {
            var id = request.Id;

            var entity = await this.catRepository.Collection().FindAsync(id);

            if (entity is null)
            {
                return new FeatureResult<GetByIdOutputModel>(new NotFoundResult());
            }

            var outputModel = this.mapper.Map<GetByIdOutputModel>(entity);
            return new FeatureResult<GetByIdOutputModel>(new OkObjectResult(outputModel));
        }
    }
}
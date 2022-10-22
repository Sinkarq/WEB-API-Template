using AutoMapper;
using MediatR;
using YourProject.Data.Common.Repositories;
using YourProject.Server.Infrastructure.Mapping.Interfaces;

namespace YourProject.Server.Features.Cats.Queries.GetById;

public class GetByIdQueryModel : 
    IRequest<GetByIdOutputModel>
{
    public int Id { get; set; }
    
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQueryModel, GetByIdOutputModel>
    {
        private readonly IDeletableEntityRepository<Cat> catRepository;
        private readonly IMapper mapper;

        public GetByIdQueryHandler(IDeletableEntityRepository<Cat> catRepository, IMapper mapper)
        {
            this.catRepository = catRepository;
            this.mapper = mapper;
        }

        public async Task<GetByIdOutputModel> Handle(GetByIdQueryModel request, CancellationToken cancellationToken)
        {
            var id = request.Id;

            var entity = await this.catRepository.Collection().FindAsync(id);

            var outputModel = this.mapper.Map<GetByIdOutputModel>(entity);

            return outputModel;
        }
    }
}
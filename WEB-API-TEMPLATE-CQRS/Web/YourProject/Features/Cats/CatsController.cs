using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneOf;
using YourProject.Server.Features.Cats.Commands.CreateCommand;
using YourProject.Server.Features.Cats.Queries.GetById;
using YourProject.Server.Infrastructure;

namespace YourProject.Server.Features.Cats;

public class CatsController : ApiController
{
    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<GetByIdOutputModel>> GetById([FromRoute] GetByIdQueryModel model)
        => await this.Mediator.Send(model);

    // OrNotFound is a global action located in the Infrastructure Project
    // And all it does is this check
    // if (entity == null) return new NotFoundResult();
    // if not return the model
    // So it saves you everytime you have to check for
    // if you have null or valid entity that has been retrieved from the db

    [HttpPost]
    [Authorize]
    [Route(nameof(CreateCat))]
    public async Task<ActionResult<CreateCommandOutputModel>> CreateCat(CreateCommandModel model)
        => await this.Mediator.Send(model);
}
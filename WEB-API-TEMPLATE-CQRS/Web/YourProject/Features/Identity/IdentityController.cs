using Microsoft.AspNetCore.Mvc;
using YourProject.Server.Features.Identity.Commands.Login;
using YourProject.Server.Features.Identity.Commands.Register;

namespace YourProject.Server.Features.Identity;

public sealed class IdentityController : ApiController
{
    [HttpPost]
    [Route(nameof(Register))]
    public async Task<ActionResult<RegisterCommandOutputModel>> Register(RegisterCommandRequestModel model)
        => await this.Mediator.Send(model);

    [HttpPost]
    [Route(nameof(Login))]
    public async Task<ActionResult<LoginCommandOutputModel>> Login(LoginCommandRequestModel model)
        => await this.Mediator.Send(model);
}
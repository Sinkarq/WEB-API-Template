using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using YourProject.Common;
using YourProject.Server.Features.Identity.Models;

namespace YourProject.Server.Features.Identity;

public sealed class IdentityController : ApiController
{
    private readonly UserManager<User> userManager;
    private readonly AppSettings appSettings;
    private readonly IIdentityService identityService;
    public IdentityController(
        UserManager<User> userManager, 
        IOptions<AppSettings> appSettings, 
        IIdentityService identityService)
    {
        this.userManager = userManager;
        this.identityService = identityService;
        this.appSettings = appSettings.Value;
    }

    [HttpPost]
    [Route(nameof(Register))]
    public async Task<IActionResult> Register(RegisterRequestModel model)
    {
        var user = new User
        {
            Email = model.Email,
            UserName = model.Username
        };
    
        var result = await this.userManager.CreateAsync(user, model.Password);
    
        if (!result.Succeeded)
        {
            BadRequest(result.Errors);
        }

        return this.Ok();
    }
    
    [HttpPost]
    [Route(nameof(Login))]
    public async Task<ActionResult<LoginResponseModel>> Login(LoginRequestModel model)
    {
        var user = await this.userManager.FindByNameAsync(model.Username);
        if (user == null)
        {
            return Unauthorized();
        }
    
        var passwordValid = await this.userManager.CheckPasswordAsync(user, model.Password);
    
        if (!passwordValid)
        {
            return Unauthorized();
        }
    
        var encryptedToken = this.identityService.GenerateJwtToken(user.Id, user.UserName, appSettings.Secret);

        return new LoginResponseModel()
        {
            Token = encryptedToken
        };
    }
}
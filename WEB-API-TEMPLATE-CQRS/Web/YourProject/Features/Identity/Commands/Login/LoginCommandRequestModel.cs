using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using YourProject.Common;
using YourProject.Server.Infrastructure;

namespace YourProject.Server.Features.Identity.Commands.Login;

public class LoginCommandRequestModel : IRequest<FeatureResult<LoginCommandOutputModel>>
{
    public string Username { get; set; }

    public string Password { get; set; }

    public class
        LoginCommandRequestHandler : IRequestHandler<LoginCommandRequestModel, FeatureResult<LoginCommandOutputModel>>
    {
        private readonly UserManager<User> userManager;
        private readonly IIdentityService identityService;
        private readonly AppSettings appSettings;

        public LoginCommandRequestHandler(UserManager<User> userManager, IIdentityService identityService,
            IOptions<AppSettings> appSettings)
        {
            this.userManager = userManager;
            this.identityService = identityService;
            this.appSettings = appSettings.Value;
        }

        public async Task<FeatureResult<LoginCommandOutputModel>> Handle(LoginCommandRequestModel request,
            CancellationToken cancellationToken)
        {
            var user = await this.userManager.FindByNameAsync(request.Username);
            if (user == null)
            {
                return new FeatureResult<LoginCommandOutputModel>(new UnauthorizedResult());
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user, request.Password);

            if (!passwordValid)
            {
                return new FeatureResult<LoginCommandOutputModel>(new UnauthorizedResult());
            }

            var encryptedToken = this.identityService.GenerateJwtToken(user.Id, user.UserName, appSettings.Secret);

            return new FeatureResult<LoginCommandOutputModel>(
                new OkObjectResult(new LoginCommandOutputModel() {Token = encryptedToken}));
        }
    }
}
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using YourProject.Common;

namespace YourProject.Server.Features.Identity.Commands.Login;

public class LoginCommandRequestModel : IRequest<LoginCommandOutputModel>
{
    public string Username { get; set; }

    public string Password { get; set; }

    public class LoginCommandRequestHandler : IRequestHandler<LoginCommandRequestModel, LoginCommandOutputModel>
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

        public async Task<LoginCommandOutputModel> Handle(LoginCommandRequestModel request,
            CancellationToken cancellationToken)
        {
            var user = await this.userManager.FindByNameAsync(request.Username);
            /*if (user == null)
            {
                return Unauthorized();
            }*/

            var passwordValid = await this.userManager.CheckPasswordAsync(user, request.Password);

            /*if (!passwordValid)
            {
                return Unauthorized();
            }*/

            var encryptedToken = this.identityService.GenerateJwtToken(user.Id, user.UserName, appSettings.Secret);

            return new LoginCommandOutputModel()
            {
                Token = encryptedToken
            };
        }
    }
}
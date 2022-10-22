using MediatR;
using Microsoft.AspNetCore.Identity;
using YourProject.Server.Infrastructure.Mapping.Interfaces;

namespace YourProject.Server.Features.Identity.Commands.Register;

public class RegisterCommandRequestModel : IRequest<RegisterCommandOutputModel>, IMapTo<User>
{
    public string Username { get; set; }
    
    public string Password { get; set; }
    
    public string Email { get; set; }
    
    public class RegisterCommandRequestModelHandler : IRequestHandler<RegisterCommandRequestModel, RegisterCommandOutputModel>
    {
        private readonly UserManager<User> userManager;

        public RegisterCommandRequestModelHandler(UserManager<User> userManager) => this.userManager = userManager;

        public async Task<RegisterCommandOutputModel> Handle(RegisterCommandRequestModel request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Email = request.Email,
                UserName = request.Username
            };
    
            var result = await this.userManager.CreateAsync(user, request.Password);
    
            /*if (!result.Succeeded)
            {
                BadRequest(result.Errors);
            }*/

            return new RegisterCommandOutputModel();
        }
    }
}

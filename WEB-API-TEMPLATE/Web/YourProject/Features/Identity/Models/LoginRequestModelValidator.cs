using FluentValidation;

namespace YourProject.Server.Features.Identity.Models;

public class LoginRequestModelValidator : AbstractValidator<LoginRequestModel>
{
    private const string ValidationMessage = "Please fill in {PropertyName}.";

    public LoginRequestModelValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage(ValidationMessage)
            .NotNull().WithMessage(ValidationMessage);

        RuleFor(x => x.Password)
            .NotNull().WithMessage(ValidationMessage)
            .NotEmpty().WithMessage(ValidationMessage);
    }
}
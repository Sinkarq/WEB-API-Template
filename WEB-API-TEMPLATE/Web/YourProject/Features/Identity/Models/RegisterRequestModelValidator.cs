using FluentValidation;

namespace YourProject.Server.Features.Identity.Models;

public class RegisterRequestModelValidator : AbstractValidator<RegisterRequestModel>
{
    private const string ValidationMessage = "Please fill in {PropertyName}.";

    public RegisterRequestModelValidator()
    {
        RuleFor(x => x.Email)
            .NotNull().WithMessage(ValidationMessage)
            .EmailAddress().WithMessage("Please fill in valid {PropertyName}")
            .NotEmpty().WithMessage(ValidationMessage);

        RuleFor(x => x.Password)
            .NotNull().WithMessage(ValidationMessage)
            .MinimumLength(8).WithMessage("{PropertyName} must be at least 8 characters long.")
            .NotEmpty().WithMessage(ValidationMessage);
        
        RuleFor(x => x.Username)
            .NotNull().WithMessage(ValidationMessage)
            .NotEmpty().WithMessage(ValidationMessage);
    }
}
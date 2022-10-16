using FluentValidation;

namespace YourProject.Server.Features.Identity.Models;

public class RegisterRequestModelValidator : AbstractValidator<RegisterRequestModel>
{
    private const string ValidationMessage = "Please fill in {PropertyName}.";

    public RegisterRequestModelValidator()
    {
        RuleFor(x => x.Email).NotNull().WithMessage(ValidationMessage);
        RuleFor(x => x.Email).EmailAddress().WithMessage("Please fill in valid {PropertyName}");
        RuleFor(x => x.Email).NotEmpty().WithMessage(ValidationMessage);
        
        RuleFor(x => x.Password).NotNull().WithMessage(ValidationMessage);
        RuleFor(x => x.Password).MinimumLength(8).WithMessage("{PropertyName} must be at least 8 characters long.");
        RuleFor(x => x.Password).NotEmpty().WithMessage(ValidationMessage);
        
        RuleFor(x => x.Username).NotNull().WithMessage(ValidationMessage);
        RuleFor(x => x.Username).NotEmpty().WithMessage(ValidationMessage);
    }
}
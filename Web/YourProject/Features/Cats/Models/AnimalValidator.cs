using FluentValidation;

namespace YourProject.Server.Features.Cats.Models;

public class AnimalValidator : AbstractValidator<Animal>
{
    private const string ValidationMessage = "Please fill in {PropertyName}.";

    public AnimalValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage(ValidationMessage);
        RuleFor(x => x.Name).NotNull().WithMessage(ValidationMessage);
    }
}
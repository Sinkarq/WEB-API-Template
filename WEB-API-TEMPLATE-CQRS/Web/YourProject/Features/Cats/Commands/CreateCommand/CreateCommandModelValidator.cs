using FluentValidation;

namespace YourProject.Server.Features.Cats.Commands.CreateCommand;

public class CreateCommandModelValidator : AbstractValidator<CreateCommandModel>
{
    public CreateCommandModelValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull();
    }
}
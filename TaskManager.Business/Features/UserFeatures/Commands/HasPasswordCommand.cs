using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.UserFeatures.Commands;

public class HasPasswordCommandValidator : AbstractValidator<HasPasswordCommand>
{
    public HasPasswordCommandValidator()
    {
        RuleFor(x => x.command.Username)
            .NotEmpty();
    }
}

public record HasPasswordCommand(HasPasswordRequest command) : IRequest<HasPasswordResponse>;
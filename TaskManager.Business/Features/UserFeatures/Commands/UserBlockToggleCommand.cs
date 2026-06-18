using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.UserFeatures.Commands;

public class UserBlockToggleCommandValidator : AbstractValidator<UserBlockToggleCommand>
{
    public UserBlockToggleCommandValidator()
    {
        RuleFor(x => x.command.Id)
            .NotEmpty();
    }
}

public record UserBlockToggleCommand(UserBlockToggleRequest command) : IRequest<UserBlockToggleResponse>;
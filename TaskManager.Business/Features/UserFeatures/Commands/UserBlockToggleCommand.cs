using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.UserFeatures.Commands;

public class UserBlockToggleCommandValidator : AbstractValidator<UserBlockToggleCommand>
{
    public UserBlockToggleCommandValidator()
    {
        RuleFor(x => x.command.UserId)
            .NotEmpty();
    }
}

public record UserBlockToggleCommand(UserBlockToggleRequest command) : IRequest<UserBlockToggleResponse>;
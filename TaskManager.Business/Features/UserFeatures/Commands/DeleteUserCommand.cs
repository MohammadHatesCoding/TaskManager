using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.UserFeatures.Commands;

public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(x => x.command.Id)
            .NotEmpty();
    }
}

public record DeleteUserCommand(DeleteUserRequest command) : IRequest<DeleteUserResponse>;
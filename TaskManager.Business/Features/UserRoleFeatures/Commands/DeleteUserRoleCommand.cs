using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.UserRoleFeatures.Commands;

public class DeleteUserRoleCommandValidator : AbstractValidator<DeleteUserRoleCommand>
{
    public DeleteUserRoleCommandValidator()
    {
        RuleFor(x => x.command.UserId)
            .NotEmpty();

        RuleFor(x => x.command.RoleId)
            .NotNull();
    }
}

public record DeleteUserRoleCommand(DeleteUserRoleRequest command) : IRequest<DeleteUserRoleResponse>;
using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.RoleFeatures.Commands;

public class DeleteRoleCommandValidator : AbstractValidator<DeleteRoleCommand>
{
    public DeleteRoleCommandValidator()
    {
        RuleFor(x => x.command.RoleId)
            .NotNull()
            .GreaterThan(0);
    }
}

public record DeleteRoleCommand(DeleteRoleRequest command) : IRequest<DeleteRoleResponse>;
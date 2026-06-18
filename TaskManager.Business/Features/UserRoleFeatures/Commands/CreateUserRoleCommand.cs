using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.UserRoleFeatures.Commands;

public class CreateUserRoleCommandValidator : AbstractValidator<CreateUserRoleCommand>
{
    public CreateUserRoleCommandValidator()
    {
        RuleFor(x => x.command.UserId)
            .NotEmpty();

        RuleFor(x => x.command.RoleId)
            .NotNull();
    }
}

public record CreateUserRoleCommand(CreateUserRoleRequest command) : IRequest<CreateUserRoleResponse>;
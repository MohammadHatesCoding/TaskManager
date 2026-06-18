using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.RoleFeatures.Commands;

public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(x => x.command.Title)
            .NotEmpty()
            .NotNull()
            .MaximumLength(100);

        RuleFor(x => x.command.Type)
            .NotEmpty()
            .NotNull();
    }
}

public record CreateRoleCommand(CreateRoleRequest command) : IRequest<CreateRoleResponse>;
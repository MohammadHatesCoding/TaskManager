using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.RoleFeatures.Commands;

public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
{
    public UpdateRoleCommandValidator()
    {
        RuleFor(x => x.command.Id)
            .NotNull()
            .GreaterThan(0);

        RuleFor(x => x.command.Title)
            .NotEmpty()
            .NotNull()
            .MaximumLength(100);

        RuleFor(x => x.command.Type)
            .NotEmpty()
            .NotNull();
    }
}

public record UpdateRoleCommand(UpdateRoleRequest command) : IRequest<UpdateRoleResponse>;
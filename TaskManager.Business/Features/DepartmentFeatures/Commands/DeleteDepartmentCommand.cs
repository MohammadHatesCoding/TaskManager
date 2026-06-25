using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.DepartmentFeatures.Commands;

public class DeleteDepartmentCommandValidator : AbstractValidator<DeleteDepartmentCommand>
{
    public DeleteDepartmentCommandValidator()
    {
        RuleFor(x => x.command.DepartmentId)
            .NotNull()
            .GreaterThan(0);
    }
}

public record DeleteDepartmentCommand(DeleteDepartmentRequest command) : IRequest<DeleteDepartmentResponse>;
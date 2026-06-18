using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.AssignmentEmployeeFeatures.Commands;

public class DeleteAssignmentEmployeeCommandValidator : AbstractValidator<DeleteAssignmentEmployeeCommand>
{
    public DeleteAssignmentEmployeeCommandValidator()
    {
        RuleFor(x => x.command.Id)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);
    }
}

public record DeleteAssignmentEmployeeCommand(DeleteAssignmentEmployeeRequest command) : IRequest<DeleteAssignmentEmployeeResponse>;
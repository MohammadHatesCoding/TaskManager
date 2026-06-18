using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.AssignmentEmployeeFeatures.Commands;

public class CreateAssignmentEmployeeCommandValidatior : AbstractValidator<CreateAssignmentEmployeeCommand>
{
    public CreateAssignmentEmployeeCommandValidatior()
    {
        RuleFor(x => x.command.AssignmentId)
            .NotNull()
            .NotEmpty()
            .GreaterThan(0);

        RuleFor(x => x.command.EmployeeId)
            .NotNull()
            .NotEmpty()
            .GreaterThan(0);
    }
}

public record CreateAssignmentEmployeeCommand(CreateAssignmentEmployeeRequest command) : IRequest<CreateAssignmentEmployeeResponse>;
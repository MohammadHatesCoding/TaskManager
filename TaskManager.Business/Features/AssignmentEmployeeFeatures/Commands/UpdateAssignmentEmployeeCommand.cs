using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.AssignmentEmployeeFeatures.Commands;

public class UpdateAssignmentEmployeeCommandValidator : AbstractValidator<UpdateAssignmentEmployeeCommand>
{
    public UpdateAssignmentEmployeeCommandValidator()
    {
        RuleFor(x => x.command.Id)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);

        RuleFor(x => x.command.AssignmentId)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);
    
        RuleFor(x => x.command.EmployeeId)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);
    }
}

public record UpdateAssignmentEmployeeCommand(UpdateAssignmentEmployeeRequest command) : IRequest<UpdateAssignmentEmployeeResponse>;
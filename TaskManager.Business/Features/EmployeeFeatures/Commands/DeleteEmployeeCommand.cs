using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.EmployeeFeatures.Commands;

public class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommand>
{
    public DeleteEmployeeCommandValidator()
    {
        RuleFor(x => x.command.EmployeeId)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);
    }
}

public record DeleteEmployeeCommand(DeleteEmployeeRequest command) : IRequest<DeleteEmployeeResponse>;
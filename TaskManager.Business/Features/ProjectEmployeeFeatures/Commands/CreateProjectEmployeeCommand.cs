using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.ProjectEmployeeFeatures.Commands;

public class CreateProjectEmployeeCommandValidator : AbstractValidator<CreateProjectEmployeeCommand>
{
    public CreateProjectEmployeeCommandValidator()
    {
        RuleFor(x => x.command.ProjectId)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);

        RuleFor(x => x.command.EmployeeId)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);
    }
}

public record CreateProjectEmployeeCommand(CreateProjectEmployeeRequest command) : IRequest<CreateProjectEmployeeResponse>;
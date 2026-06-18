using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.ProjectEmployeeFeatures.Commands;

public class UpdateProjectEmployeeCommandValidator : AbstractValidator<UpdateProjectEmployeeCommand>
{
    public UpdateProjectEmployeeCommandValidator()
    {
        RuleFor(x => x.command.Id)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);

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

public record UpdateProjectEmployeeCommand(UpdateProjectEmployeeRequest command) : IRequest<UpdateProjectEmployeeResponse>;
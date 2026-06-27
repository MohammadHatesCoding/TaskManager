using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.ProjectEmployeeFeatures.Commands;

public class DeleteProjectEmployeeCommandValidator : AbstractValidator<DeleteProjectEmployeeCommand>
{
    public DeleteProjectEmployeeCommandValidator()
    {
        RuleFor(x => x.command.ProjectEmployeeId)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);
    }
}

public record DeleteProjectEmployeeCommand(DeleteProjectEmployeeRequest command) : IRequest<DeleteProjectEmployeeResponse>;
using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.AssignmentFeatures.Commands;

public class CreateAssignmentCommandValidator : AbstractValidator<CreateAssignmentCommand>
{
    public CreateAssignmentCommandValidator()
    {
        RuleFor(x => x.command.Title)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.command.Describtion)
            .NotEmpty()
            .MaximumLength(700);

        RuleFor(x => x.command.Deadline)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.command.Priority)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.command.ProjectId)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);
    }
}

public record CreateAssignmentCommand(CreateAssignmentRequest command) : IRequest<CreateAssignmentResponse>;
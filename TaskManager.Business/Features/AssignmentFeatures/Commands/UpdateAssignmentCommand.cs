using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.AssignmentFeatures.Commands;

public class UpdateAssignmentCommandValidator : AbstractValidator<UpdateAssignmentCommand>
{
    public UpdateAssignmentCommandValidator()
    {
        RuleFor(x => x.command.Id)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);

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

public record UpdateAssignmentCommand(UpdateAssignmentRequest command) : IRequest<UpdateAssignmentResponse>;
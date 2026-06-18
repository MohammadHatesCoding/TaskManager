using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.CommentFeatures.Commands;

public class UpdateCommentCommandValidator : AbstractValidator<UpdateCommentCommand>
{
    public UpdateCommentCommandValidator()
    {
        RuleFor(x => x.command.Id)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);

        RuleFor(x => x.command.Content)
            .NotEmpty()
            .MaximumLength(100);

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

public record UpdateCommentCommand(UpdateCommentRequest command) : IRequest<UpdateCommentResponse>;
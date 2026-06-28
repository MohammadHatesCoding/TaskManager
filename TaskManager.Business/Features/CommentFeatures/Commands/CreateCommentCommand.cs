using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.CommentFeatures.Commands;

public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
{
    public CreateCommentCommandValidator()
    {
        RuleFor(x => x.command.Content)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.command.AssignmentId)
            .NotNull()
            .NotEmpty()
            .GreaterThan(0);
    }
}

public record CreateCommentCommand(CreateCommentRequest command) : IRequest<CreateCommentResponse>;
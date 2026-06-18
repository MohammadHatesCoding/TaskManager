using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.ProjectFeatures.Commands;

public class DeleteProjectCommandValidator : AbstractValidator<DeleteProjectCommand>
{
    public DeleteProjectCommandValidator()
    {
        RuleFor(x => x.command.Id)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);
    }
}

public record DeleteProjectCommand(DeleteProjectRequest command) : IRequest<DeleteProjectResponse>;
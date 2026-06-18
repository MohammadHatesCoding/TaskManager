using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.ProjectFeatures.Commands;

public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectCommandValidator()
    {
        RuleFor(x => x.command.Title)
            .NotEmpty()
            .NotNull()
            .MaximumLength(100);

        RuleFor(x => x.command.Describtion)
            .NotEmpty()
            .NotNull()
            .MaximumLength(100);

        RuleFor(x => x.command.CompanyId)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);

        RuleFor(x => x.command.StartDate)
            .NotNull();

        RuleFor(x => x.command.Status)
            .NotEmpty()
            .NotNull();
    }
}

public record CreateProjectCommand(CreateProjectRequest command) : IRequest<CreateProjectResponse>;
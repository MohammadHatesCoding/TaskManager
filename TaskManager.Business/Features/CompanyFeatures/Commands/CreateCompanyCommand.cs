using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.CompanyFeatures.Commands;

public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
{
    public CreateCompanyCommandValidator()
    {
        RuleFor(x => x.command.Title)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.command.Address)
            .NotEmpty()
            .MaximumLength(300);

        RuleFor(x => x.command.RegisterationNumber)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.command.Blog)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.command.OwnerId)
            .NotNull()
            .NotEmpty();
    }
}

public record CreateCompanyCommand(CreateCompanyRequest command) : IRequest<CreateCompanyResponse>;
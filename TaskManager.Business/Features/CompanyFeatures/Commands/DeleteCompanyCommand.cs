using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.CompanyFeatures.Commands;

public class DeleteCompanyCommandValidator : AbstractValidator<DeleteCompanyCommand>
{
    public DeleteCompanyCommandValidator()
    {
        RuleFor(x => x.command.Id)
            .NotNull()
            .NotEmpty()
            .GreaterThan(0);
    }
}

public record DeleteCompanyCommand(DeleteCompanyRequest command) : IRequest<DeleteCompanyResponse>;
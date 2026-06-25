using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.CompanyFeatures.Queries;

public class GetCompanyDetailsQueryValidator : AbstractValidator<GetCompanyDetailsQuery>
{
    public GetCompanyDetailsQueryValidator()
    {
        RuleFor(x => x.query.CompanyId)
            .NotNull()
            .NotEmpty()
            .GreaterThan(0);
    }
}

public record GetCompanyDetailsQuery(GetCompanyDetailsRequest query) : IRequest<GetCompanyDetailsResponse>;
using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.CompanyFeatures.Queries;

public class GetAllCompaniesQueryValidator : AbstractValidator<GetAllCompaniesQuery>
{
    public GetAllCompaniesQueryValidator()
    {

    }
}


public record GetAllCompaniesQuery(GetAllCompaniesRequest query) : IRequest<List<GetAllCompaniesResponse>>;
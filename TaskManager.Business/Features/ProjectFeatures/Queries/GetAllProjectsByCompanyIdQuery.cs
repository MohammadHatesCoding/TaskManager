using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.ProjectFeatures.Queries;

public class GetAllProjectsByCompanyIdQueryValidator : AbstractValidator<GetAllProjectsByCompanyIdQuery>
{
    public GetAllProjectsByCompanyIdQueryValidator()
    {
        RuleFor(x => x.query.CompanyId)
            .NotNull();
    }
}

public record GetAllProjectsByCompanyIdQuery(GetAllProjectsByCompanyIdRequest query) : IRequest<List<GetAllProjectsByCompanyIdResponse>>;
using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.ProjectFeatures.Queries;

public class GetProjectDetailsQueryValidator : AbstractValidator<GetProjectDetailsQuery>
{
    public GetProjectDetailsQueryValidator()
    {
        RuleFor(x => x.query.ProjectId)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);
    }
}

public record GetProjectDetailsQuery(GetProjectDetailsRequest query) : IRequest<GetProjectDetailsResponse>;
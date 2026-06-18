using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.RoleFeatures.Queries;

public class GetRoleDetailsQueryValidator : AbstractValidator<GetRoleDetailsQuery>
{
    public GetRoleDetailsQueryValidator()
    {
        RuleFor(x => x.query.Id)
            .NotNull()
            .GreaterThan(0);
    }
}

public record GetRoleDetailsQuery(GetRoleDetailsRequest query) : IRequest<GetRoleDetailsResponse>;
using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.UserRoleFeatures.Queries;

public class GetUserRolesByRoleIdQueryValidator : AbstractValidator<GetUserRolesByRoleIdQuery>
{
    public GetUserRolesByRoleIdQueryValidator()
    {
        RuleFor(x => x.query.RoleId)
            .NotNull();
    }
}

public record GetUserRolesByRoleIdQuery(GetUserRolesByRoleIdRequest query) : IRequest<List<GetUserRolesByRoleIdResponse>>;
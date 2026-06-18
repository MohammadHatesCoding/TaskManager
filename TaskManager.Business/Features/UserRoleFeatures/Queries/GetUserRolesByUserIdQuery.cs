using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.UserRoleFeatures.Queries;

public class GetUserRolesByUserIdQueryValidator : AbstractValidator<GetUserRolesByUserIdQuery>
{
    public GetUserRolesByUserIdQueryValidator()
    {
        RuleFor(x => x.query.UserId)
            .NotEmpty();
    }
}

public record GetUserRolesByUserIdQuery(GetUserRolesByUserIdRequest query) : IRequest<List<GetUserRolesByUserIdResponse>>;
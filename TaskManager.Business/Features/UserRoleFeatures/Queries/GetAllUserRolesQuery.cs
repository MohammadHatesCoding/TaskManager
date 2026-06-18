using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.UserRoleFeatures.Queries;

public class GetAllUserRolesQueryValidator : AbstractValidator<GetAllUserRolesQuery>
{
    public GetAllUserRolesQueryValidator()
    {
    
    }
}

public record GetAllUserRolesQuery(GetAllUserRolesRequest query) : IRequest<List<GetAllUserRolesResponse>>;
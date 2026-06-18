using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.RoleFeatures.Queries;

public class GetAllRolesQueryValidator : AbstractValidator<GetAllRolesQuery>
{
    public GetAllRolesQueryValidator()
    {

    }
}

public record GetAllRolesQuery(GetAllRolesRequest query) : IRequest<List<GetAllRolesResponse>>;
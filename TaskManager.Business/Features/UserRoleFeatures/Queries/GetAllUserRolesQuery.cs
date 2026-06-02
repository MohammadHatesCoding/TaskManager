using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.UserRoleFeatures.Queries;

public record GetAllUserRolesQuery(GetAllUserRolesRequest query) : IRequest<List<GetAllUserRolesResponse>>;
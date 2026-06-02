using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.RoleFeatures.Queries;

public record GetAllRolesQuery(GetAllRolesRequest query) : IRequest<List<GetAllRolesResponse>>;
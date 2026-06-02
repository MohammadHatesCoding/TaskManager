using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.UserRoleFeatures.Queries;

public record GetUserRolesByRoleIdQuery(GetUserRolesByRoleIdRequest query) : IRequest<List<GetUserRolesByRoleIdResponse>>;
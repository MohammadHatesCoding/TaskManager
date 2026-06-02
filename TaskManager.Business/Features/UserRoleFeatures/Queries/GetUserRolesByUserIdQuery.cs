using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.UserRoleFeatures.Queries;

public record GetUserRolesByUserIdQuery(GetUserRolesByUserIdRequest query) : IRequest<List<GetUserRolesByUserIdResponse>>;
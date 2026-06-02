using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.RoleFeatures.Queries;

public record GetRoleDetailsQuery(GetRoleDetailsRequest query) : IRequest<GetRoleDetailsResponse>;
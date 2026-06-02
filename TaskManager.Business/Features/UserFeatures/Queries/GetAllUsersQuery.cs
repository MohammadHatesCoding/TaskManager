using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.UserFeatures.Queries;

public record GetAllUsersQuery(GetAllUsersRequest query) : IRequest<List<GetAllUsersResponse>>;
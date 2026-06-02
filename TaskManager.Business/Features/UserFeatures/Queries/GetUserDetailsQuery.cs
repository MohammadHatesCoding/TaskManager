using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.UserFeatures.Queries;

public record GetUserDetailsQuery(GetProfileDetailsRequest query) : IRequest<GetUserDetailsResponse>;
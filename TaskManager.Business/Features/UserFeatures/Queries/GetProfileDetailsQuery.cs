using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.UserFeatures.Queries;

public record GetProfileDetailsQuery(GetProfileDetailsRequest query) : IRequest<GetProfileDetailsResponse>;
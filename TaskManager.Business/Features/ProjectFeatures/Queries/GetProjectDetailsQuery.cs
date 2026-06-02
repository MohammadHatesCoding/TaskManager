using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.ProjectFeatures.Queries;

public record GetProjectDetailsQuery(GetProjectDetailsRequest query) : IRequest<GetProjectDetailsResponse>;
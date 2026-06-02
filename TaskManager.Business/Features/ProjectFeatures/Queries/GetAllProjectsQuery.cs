using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.ProjectFeatures.Queries;

public record GetAllProjectsQuery(GetAllProjectsRequest query) : IRequest<List<GetAllProjectsResponse>>;
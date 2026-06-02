using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.AssignmentFeatures.Queries;

public record GetAllAssignmentsQuery(GetAllAssignmentsRequest query) : IRequest<List<GetAllAssignmentsResponse>>;
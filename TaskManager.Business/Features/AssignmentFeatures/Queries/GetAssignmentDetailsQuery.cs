using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.AssignmentFeatures.Queries;

public record GetAssignmentDetailsQuery(GetAssignmentDetailsRequest query) : IRequest<GetAssignmentDetailsResponse>;
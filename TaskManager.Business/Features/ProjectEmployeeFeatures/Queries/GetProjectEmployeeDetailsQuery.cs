using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.ProjectEmployeeFeatures.Queries;

public record GetProjectEmployeeDetailsQuery(GetProjectEmployeeDetailsRequest query) : IRequest<GetProjectEmployeeDetailsResponse>;
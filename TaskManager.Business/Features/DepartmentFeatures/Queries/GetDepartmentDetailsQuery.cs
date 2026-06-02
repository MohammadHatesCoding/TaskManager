using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.DepartmentFeatures.Queries;

public record GetDepartmentDetailsQuery(GetDepartmentDetailsRequest query) : IRequest<GetDepartmentDetailsResponse>;
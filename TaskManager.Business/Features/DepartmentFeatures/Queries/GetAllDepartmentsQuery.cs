using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.DepartmentFeatures.Queries;

public record GetAllDepartmentsQuery(GetAllDepartmentsRequest query) : IRequest<List<GetAllDepartmentsResponse>>;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.EmployeeFeatures.Queries;

public record GetAllEmployeesQuery(GetAllEmployeesRequest query) : IRequest<List<GetAllEmployeesResponse>>;
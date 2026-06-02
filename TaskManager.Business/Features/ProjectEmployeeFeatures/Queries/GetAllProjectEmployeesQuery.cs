using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.ProjectEmployeeFeatures.Queries;

public record GetAllProjectEmployeesQuery(GetAllProjectEmployeesRequest query) : IRequest<List<GetAllProjectEmployeesResponse>>;
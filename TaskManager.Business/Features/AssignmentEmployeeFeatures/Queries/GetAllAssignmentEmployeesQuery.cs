using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.AssignmentEmployeeFeatures.Queries;

public record GetAllAssignmentEmployeesQuery(GetAllAssignmentEmployeesRequest query) : IRequest<List<GetAllAssignmentEmployeesResponse>>;
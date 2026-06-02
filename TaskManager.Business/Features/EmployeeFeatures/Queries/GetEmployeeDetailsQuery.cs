using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.EmployeeFeatures.Queries;

public record GetEmployeeDetailsQuery(GetEmployeeDetailsRequest query) : IRequest<GetEmployeeDetailsResponse>;
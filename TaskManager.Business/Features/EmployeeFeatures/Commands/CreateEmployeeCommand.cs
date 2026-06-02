using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.EmployeeFeatures.Commands;

public record CreateEmployeeCommand(CreateEmployeeRequest command) : IRequest<CreateEmployeeResponse>;
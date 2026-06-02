using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.EmployeeFeatures.Commands;

public record UpdateEmployeeCommand(UpdateEmployeeRequest command) : IRequest<UpdateEmployeeResponse>;
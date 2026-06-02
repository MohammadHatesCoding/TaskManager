using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.ProjectEmployeeFeatures.Commands;

public record CreateProjectEmployeeCommand(CreateProjectEmployeeRequest command) : IRequest<CreateProjectEmployeeResponse>;
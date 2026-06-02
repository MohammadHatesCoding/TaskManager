using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.ProjectEmployeeFeatures.Commands;

public record DeleteProjectEmployeeCommand(DeleteProjectEmployeeRequest command) : IRequest<DeleteProjectEmployeeResponse>;
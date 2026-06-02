using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.ProjectEmployeeFeatures.Commands;

public record UpdateProjectEmployeeCommand(UpdateProjectEmployeeRequest command) : IRequest<UpdateProjectEmployeeResponse>;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.ProjectFeatures.Commands;

public record UpdateProjectCommand(UpdateProjectRequest command) : IRequest<UpdateProjectResponse>;
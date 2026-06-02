using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.ProjectFeatures.Commands;

public record DeleteProjectCommand(DeleteProjectRequest command) : IRequest<DeleteProjectResponse>;
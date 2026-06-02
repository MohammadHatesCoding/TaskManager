using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.ProjectFeatures.Commands;

public record CreateProjectCommand(CreateProjectRequest command) : IRequest<CreateProjectResponse>;
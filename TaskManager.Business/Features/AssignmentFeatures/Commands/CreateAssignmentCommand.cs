using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.AssignmentFeatures.Commands;

public record CreateAssignmentCommand(CreateAssignmentRequest command) : IRequest<CreateAssignmentResponse>;
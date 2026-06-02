using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.AssignmentFeatures.Commands;

public record DeleteAssignmentCommand(DeleteAssignmentRequest command) : IRequest<DeleteAssignmentResponse>;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.AssignmentFeatures.Commands;

public record UpdateAssignmentCommand(UpdateAssignmentRequest command) : IRequest<UpdateAssignmentResponse>;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.UserFeatures.Commands;

public record HasPasswordCommand(HasPasswordRequest command) : IRequest<HasPasswordResponse>;
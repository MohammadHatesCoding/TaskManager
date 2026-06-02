using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.AuthFeatures.Commands;

public record CreatePasswordCommand(CreatePasswordRequest command) : IRequest<CreatePasswordResponse>;
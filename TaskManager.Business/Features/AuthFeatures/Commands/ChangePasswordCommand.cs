using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.AuthFeatures.Commands;

public record ChangePasswordCommand(ChangePasswordRequest command) : IRequest<ChangePasswordResponse>;
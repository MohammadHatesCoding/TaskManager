using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.AuthFeatures.Commands;

public record ResetPasswordCommand(ResetPasswordRequest command) : IRequest<ResetPasswordResponse>;
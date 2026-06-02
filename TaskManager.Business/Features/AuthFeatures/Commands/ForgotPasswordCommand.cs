using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.AuthFeatures.Commands;

public record ForgotPasswordCommand(ForgotPasswordRequest command) : IRequest<ForgotPasswordResponse>;
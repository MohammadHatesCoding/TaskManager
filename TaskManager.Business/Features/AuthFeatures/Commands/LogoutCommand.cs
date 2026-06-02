using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.AuthFeatures.Commands;

public record LogoutCommand(LogoutRequest command) : IRequest<LogoutResponse>;
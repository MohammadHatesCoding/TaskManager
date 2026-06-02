using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.AuthFeatures.Commands;

public record RegisterCommand(RegisterRequest command) : IRequest<RegisterResponse>;
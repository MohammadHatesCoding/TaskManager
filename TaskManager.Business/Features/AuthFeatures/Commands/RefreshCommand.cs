using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.AuthFeatures.Commands;

public record RefreshCommand(RefreshRequest command) : IRequest<RefreshResponse>;
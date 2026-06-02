using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.UserFeatures.Commands;

public record CreateUserCommand(CreateUserRequest command) : IRequest<CreateUserResponse>;
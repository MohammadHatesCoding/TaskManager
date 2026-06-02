using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.UserFeatures.Commands;

public record DeleteUserCommand(DeleteUserRequest command) : IRequest<DeleteUserResponse>;
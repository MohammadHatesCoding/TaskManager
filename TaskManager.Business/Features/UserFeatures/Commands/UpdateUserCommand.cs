using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.UserFeatures.Commands;

public record UpdateUserCommand(UpdateUserRequest command) : IRequest<UpdateUserResponse>;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.UserRoleFeatures.Commands;

public record CreateUserRoleCommand(CreateUserRoleRequest command) : IRequest<CreateUserRoleResponse>;
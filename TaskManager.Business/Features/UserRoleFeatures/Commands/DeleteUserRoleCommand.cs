using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.UserRoleFeatures.Commands;

public record DeleteUserRoleCommand(DeleteUserRoleRequest command) : IRequest<DeleteUserRoleResponse>;
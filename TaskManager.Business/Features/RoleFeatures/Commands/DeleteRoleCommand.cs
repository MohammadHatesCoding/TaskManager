using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.RoleFeatures.Commands;

public record DeleteRoleCommand(DeleteRoleRequest command) : IRequest<DeleteRoleResponse>;
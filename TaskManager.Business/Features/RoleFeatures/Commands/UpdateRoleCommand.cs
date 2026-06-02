using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.RoleFeatures.Commands;

public record UpdateRoleCommand(UpdateRoleRequest command) : IRequest<UpdateRoleResponse>;
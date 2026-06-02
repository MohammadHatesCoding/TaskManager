using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.RoleFeatures.Commands;

public record CreateRoleCommand(CreateRoleRequest command) : IRequest<CreateRoleResponse>;
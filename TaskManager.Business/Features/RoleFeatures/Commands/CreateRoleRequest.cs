using TaskManager.Shared.Enums;

namespace TaskManager.Business.Features.RoleFeatures.Commands;

public record CreateRoleRequest(string Title, RoleType Type);
namespace TaskManager.Business.Features.UserRoleFeatures.Commands;

public record CreateUserRoleRequest(Guid UserId, int RoleId);
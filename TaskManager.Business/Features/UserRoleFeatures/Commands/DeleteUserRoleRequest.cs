namespace TaskManager.Business.Features.UserRoleFeatures.Commands;

public record DeleteUserRoleRequest(Guid UserId, int RoleId);
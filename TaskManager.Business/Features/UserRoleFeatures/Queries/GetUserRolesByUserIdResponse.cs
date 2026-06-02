namespace TaskManager.Business.Features.UserRoleFeatures.Queries;

public record GetUserRolesByUserIdResponse(Guid UserId, int RoleId);
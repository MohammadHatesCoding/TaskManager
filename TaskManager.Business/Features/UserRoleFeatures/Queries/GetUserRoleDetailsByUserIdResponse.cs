namespace TaskManager.Business.Features.UserRoleFeatures.Queries;

public record GetUserRoleDetailsByUserIdResponse(Guid UserId, int RoleId, string RoleTitle);
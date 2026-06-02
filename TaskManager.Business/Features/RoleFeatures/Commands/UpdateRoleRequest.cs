namespace TaskManager.Business.Features.RoleFeatures.Commands;

public record UpdateRoleRequest(int Id, string Title, int Type);
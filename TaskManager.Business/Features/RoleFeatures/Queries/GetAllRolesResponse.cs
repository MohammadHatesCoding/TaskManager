namespace TaskManager.Business.Features.RoleFeatures.Queries;

public record GetAllRolesResponse(int Id, string Title, int? ManagerId);
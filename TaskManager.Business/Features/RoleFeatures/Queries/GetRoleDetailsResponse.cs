namespace TaskManager.Business.Features.RoleFeatures.Queries;

public record GetRoleDetailsResponse(int Id, string Title, int? ManagerId, List<int> Employees);
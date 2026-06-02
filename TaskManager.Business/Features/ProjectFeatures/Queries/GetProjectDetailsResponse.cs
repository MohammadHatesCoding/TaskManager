namespace TaskManager.Business.Features.ProjectFeatures.Queries;

public record GetProjectDetailsResponse(int Id, string Title, int? ManagerId, List<int> Employees);
namespace TaskManager.Business.Features.ProjectEmployeeFeatures.Queries;

public record GetProjectEmployeeDetailsResponse(int Id, string Title, int? ManagerId, List<int> Employees);
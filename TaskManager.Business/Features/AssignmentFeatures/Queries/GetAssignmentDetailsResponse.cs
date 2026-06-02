namespace TaskManager.Business.Features.AssignmentFeatures.Queries;

public record GetAssignmentDetailsResponse(int Id, string Title, int? ManagerId, List<int> Employees);
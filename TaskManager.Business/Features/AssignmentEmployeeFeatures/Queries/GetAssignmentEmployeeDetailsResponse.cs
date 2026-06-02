namespace TaskManager.Business.Features.AssignmentEmployeeFeatures.Queries;

public record GetAssignmentEmployeeDetailsResponse(int Id, string Title, int? ManagerId, List<int> Employees);
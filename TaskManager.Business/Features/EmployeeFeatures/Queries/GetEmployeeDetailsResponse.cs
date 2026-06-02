namespace TaskManager.Business.Features.EmployeeFeatures.Queries;

public record GetEmployeeDetailsResponse(int Id, string Title, int? ManagerId, List<int> Employees);
namespace TaskManager.Business.Features.DepartmentFeatures.Queries;

public record GetDepartmentDetailsResponse(int Id, string Title, int? ManagerId, List<GetEmployeesByDepartmentId>? Employees);
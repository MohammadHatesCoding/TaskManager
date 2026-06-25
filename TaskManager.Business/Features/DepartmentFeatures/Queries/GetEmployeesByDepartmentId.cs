namespace TaskManager.Business.Features.DepartmentFeatures.Queries;

public record GetEmployeesByDepartmentId(Guid UserId, int EmployeeId, string Name, string LastName);
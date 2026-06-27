namespace TaskManager.Business.Features.ProjectEmployeeFeatures.Queries;

public record GetAllProjectEmployeesResponse(int Id, int ProjectId, int EmployeeId, string Name, string LastName);
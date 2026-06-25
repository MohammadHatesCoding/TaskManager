namespace TaskManager.Business.Features.EmployeeFeatures.Queries;

public record GetAllEmployeesByCompanyIdResponse(int Id, string Name, string LastName, int? ManagerId);
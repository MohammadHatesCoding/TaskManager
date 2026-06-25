namespace TaskManager.Business.Features.EmployeeFeatures.Queries;

public record GetAllEmployeesResponse(int Id, string Name, string LastName, int? ManagerId, string CompanyTitle, string DepartmentTitle);
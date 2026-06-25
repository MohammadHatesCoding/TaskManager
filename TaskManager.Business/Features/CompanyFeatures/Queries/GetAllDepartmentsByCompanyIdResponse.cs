namespace TaskManager.Business.Features.CompanyFeatures.Queries;

public record GetAllDepartmentsByCompanyIdResponse(int Id, string Title, int? ManagerId);
namespace TaskManager.Business.Features.DepartmentFeatures.Queries;

public record GetAllDepartmentsResponse(int Id, string Title, int? ManagerId);
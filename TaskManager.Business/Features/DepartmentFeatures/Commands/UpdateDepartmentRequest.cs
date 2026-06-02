namespace TaskManager.Business.Features.DepartmentFeatures.Commands;

public record UpdateDepartmentRequest(int Id, string Title, int? ManagerId, int CompanyId);
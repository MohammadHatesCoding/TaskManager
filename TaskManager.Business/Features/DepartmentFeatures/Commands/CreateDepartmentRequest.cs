namespace TaskManager.Business.Features.DepartmentFeatures.Commands;

public record CreateDepartmentRequest(string Title, int? ManagerId, int CompanyId);
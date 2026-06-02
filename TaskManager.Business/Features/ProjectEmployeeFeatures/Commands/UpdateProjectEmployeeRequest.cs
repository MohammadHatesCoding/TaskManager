namespace TaskManager.Business.Features.ProjectEmployeeFeatures.Commands;

public record UpdateProjectEmployeeRequest(int Id, int ProjectId, int EmployeeId);
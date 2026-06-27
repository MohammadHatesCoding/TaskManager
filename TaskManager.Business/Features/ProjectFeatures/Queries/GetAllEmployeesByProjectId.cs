namespace TaskManager.Business.Features.ProjectFeatures.Queries;

public record GetAllEmployeesByProjectId(Guid UserId, int EmployeeId, string Name, string LastName);
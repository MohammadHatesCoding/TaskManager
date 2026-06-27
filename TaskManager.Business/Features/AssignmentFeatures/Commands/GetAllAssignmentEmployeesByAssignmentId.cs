namespace TaskManager.Business.Features.AssignmentFeatures.Commands;

public record GetAllAssignmentEmployeesByAssignmentId(Guid UserId, int EmployeeId, string Name, string LastName);
namespace TaskManager.Business.Features.AssignmentEmployeeFeatures.Commands;

public record UpdateAssignmentEmployeeRequest(int Id, int AssignmentId, int EmployeeId);
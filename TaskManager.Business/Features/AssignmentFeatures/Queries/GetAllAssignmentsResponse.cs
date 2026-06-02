namespace TaskManager.Business.Features.AssignmentFeatures.Queries;

public record GetAllAssignmentsResponse(int Id, string Title, int? ManagerId);
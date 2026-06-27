using TaskManager.Shared.Enums;

namespace TaskManager.Business.Features.AssignmentFeatures.Queries;

public record GetAllAssignmentsResponse(int Id, string Title, DateTime Deadline, AssignmentPriority Priority, Status Status);
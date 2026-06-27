using TaskManager.Shared.Enums;

namespace TaskManager.Business.Features.AssignmentFeatures.Commands;

public record UpdateAssignmentRequest(int Id, string Title, string Description, 
    DateTime Deadline, AssignmentPriority Priority, Status Status, int ProjectId);
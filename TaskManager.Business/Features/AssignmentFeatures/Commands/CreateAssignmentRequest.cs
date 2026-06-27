using TaskManager.Shared.Enums;

namespace TaskManager.Business.Features.AssignmentFeatures.Commands;

public record CreateAssignmentRequest(string Title, string Describtion, DateTime Deadline, AssignmentPriority Priority,
    Status Status, int ProjectId);
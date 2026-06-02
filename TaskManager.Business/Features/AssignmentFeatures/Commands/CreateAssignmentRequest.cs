namespace TaskManager.Business.Features.AssignmentFeatures.Commands;

public record CreateAssignmentRequest(string Title, string Describtion, DateTime Deadline, string Priority,
    string Status, int ProjectId);
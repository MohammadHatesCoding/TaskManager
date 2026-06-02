namespace TaskManager.Business.Features.AssignmentFeatures.Commands;

public record UpdateAssignmentRequest(int Id, string Title, string Describtion, 
    DateTime Deadline, string Priority, string Status, int ProjectId);
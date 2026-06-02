namespace TaskManager.Business.Features.CommentFeatures.Commands;

public record CreateCommentRequest(string Content, int AssignmentId, int EmployeeId, int? RepliedToId);
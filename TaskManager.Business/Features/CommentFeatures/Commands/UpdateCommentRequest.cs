namespace TaskManager.Business.Features.CommentFeatures.Commands;

public record UpdateCommentRequest(int Id, string Content, int AssignmentId, int? RepliedToId);
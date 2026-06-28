namespace TaskManager.Business.Features.CommentFeatures.Queries;

public record GetAllCommentsResponse(int Id, int AssignmentId, int AuthorEmployeeId,
    int? RepliedToId, string AuthorName, string AuthorLastName);
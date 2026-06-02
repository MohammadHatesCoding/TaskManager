namespace TaskManager.Business.Features.CommentFeatures.Queries;

public record GetAllCommentsResponse(int Id, string Title, int? ManagerId);
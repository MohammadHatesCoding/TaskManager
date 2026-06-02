namespace TaskManager.Business.Features.CommentFeatures.Queries;

public record GetCommentDetailsResponse(int Id, string Title, int? ManagerId, List<int> Employees);
namespace TaskManager.Business.Features.ProjectFeatures.Queries;

public record GetAllProjectsResponse(int Id, string Title, int? ManagerId);
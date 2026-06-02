namespace TaskManager.Business.Features.ProjectFeatures.Commands;

public record CreateProjectRequest(string Title, string Describtion, int CompanyId, DateTime StartDate,
    DateTime? EndDate, string Status);
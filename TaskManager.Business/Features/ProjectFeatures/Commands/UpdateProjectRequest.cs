namespace TaskManager.Business.Features.ProjectFeatures.Commands;

public record UpdateProjectRequest(int Id, string Title, string Describtion, 
    int CompanyId, DateTime StartDate, DateTime? EndDate, string Status);
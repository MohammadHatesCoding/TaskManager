using TaskManager.Shared.Enums;

namespace TaskManager.Business.Features.ProjectFeatures.Queries;

public record GetProjectDetailsResponse(int Id, string Title, string Describtion,
    DateTime StartDate, DateTime? EndDate, ProjectStatus Status, List<GetAllEmployeesByProjectId> ProjectEmployees);
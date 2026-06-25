namespace TaskManager.Business.Features.CompanyFeatures.Queries;

public record GetCompanyDetailsResponse(int Id, string Title, string Address, DateTime EstablishDate,
    int RegisterationNumber, string Blog, Guid OwnerId, bool IsActive, bool IsBlocked, List<GetAllDepartmentsByCompanyIdResponse>? Departments);
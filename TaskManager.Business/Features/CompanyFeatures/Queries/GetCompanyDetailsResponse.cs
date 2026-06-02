namespace TaskManager.Business.Features.CompanyFeatures.Queries;

public record GetCompanyDetailsResponse(int Id, string Title, Guid? LogoId);
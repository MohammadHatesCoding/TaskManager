namespace TaskManager.Business.Features.CompanyFeatures.Commands;

public record UpdateCompanyRequest(int Id, string Title, string Address, DateTime EstablishDate,
    int RegisterationNumber, string Blog, Guid? LogoId, Guid OwnerId);
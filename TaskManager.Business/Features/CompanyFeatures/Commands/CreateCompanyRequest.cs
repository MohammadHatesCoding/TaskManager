namespace TaskManager.Business.Features.CompanyFeatures.Commands;

public record CreateCompanyRequest(string Title, string Address, DateTime EstablishDate,
    int RegisterationNumber, string Blog, Guid OwnerId/*, IFormFile? LogoId*/);
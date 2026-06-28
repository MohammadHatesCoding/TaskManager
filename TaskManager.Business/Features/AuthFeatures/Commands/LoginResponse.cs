namespace TaskManager.Business.Features.AuthFeatures.Commands;

public record LoginResponse(string AccessToken, string RefreshToken, DateTime AccessTokenExpiresAt,
    List<AssociatedCompaniesDto> AssociatedCompanies);
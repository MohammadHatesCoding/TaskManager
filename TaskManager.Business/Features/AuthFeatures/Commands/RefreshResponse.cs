namespace TaskManager.Business.Features.AuthFeatures.Commands;

public record RefreshResponse(string AccessToken, string RefreshToken, DateTime AccessTokenExpiresAt);
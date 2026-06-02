namespace TaskManager.Business.Features.AuthFeatures.Commands;

public record RefreshRequest(string RefreshToken, Guid UserId);
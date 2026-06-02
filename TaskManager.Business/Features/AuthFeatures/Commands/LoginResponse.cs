using Microsoft.Win32.SafeHandles;

namespace TaskManager.Business.Features.AuthFeatures.Commands;

public record LoginResponse(string AccessToken, string RefreshToken, DateTime AccessTokenExpiresAt);
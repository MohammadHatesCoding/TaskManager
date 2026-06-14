namespace TaskManager.Business.Features.AuthFeatures.Commands;

public record CreatePasswordRequest(Guid UserId, string Password, string ConfirmPassword);
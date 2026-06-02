namespace TaskManager.Business.Features.AuthFeatures.Commands;

public record ResetPasswordRequest(string ResetPasswordToken, string Password, string ConfirmPassword);
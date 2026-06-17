namespace TaskManager.Business.Features.AuthFeatures.Commands;

public record ResetPasswordRequest(string RawResetPasswordToken, string Password, string ConfirmPassword);
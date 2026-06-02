namespace TaskManager.Business.Features.AuthFeatures.Commands;

public record ChangePasswordRequest(string OldPassword, string NewPassword, string ConfirmNewPassword);
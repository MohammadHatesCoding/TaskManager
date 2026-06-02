namespace TaskManager.Business.Features.AuthFeatures.Commands;

public record CheckOTPRequest(string username, string otp);
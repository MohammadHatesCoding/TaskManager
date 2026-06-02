namespace TaskManager.Business.Abstraction.Interfaces.Services;

public interface IOTPService
{
    (string otp, string hashedOtp) GenerateOtpAsync();
    bool VerifyOtpAsync(string storedOtpHash, string otp);
}
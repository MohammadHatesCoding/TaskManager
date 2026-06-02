namespace TaskManager.Business.Abstraction.Interfaces.Services;

public interface IPasswordService
{
    string HashPassword(string password);
    bool VerifyPassword(string storedHash, string password);
    string GeneratePasswordResetToken();
}
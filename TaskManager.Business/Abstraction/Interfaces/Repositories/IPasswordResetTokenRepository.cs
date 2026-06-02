using TaskManager.Domain.Models;

namespace TaskManager.Business.Abstraction.Interfaces.Repositories;

public interface IPasswordResetTokenRepository
{
    Task CreateAsync(PasswordResetToken PasswordResetToken);
    Task<PasswordResetToken> GetByTokenHashAsync(string Token);
}
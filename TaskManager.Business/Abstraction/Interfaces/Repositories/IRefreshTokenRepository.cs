using TaskManager.Domain.Models;

namespace TaskManager.Business.Abstraction.Interfaces.Repositories;

public interface IRefreshTokenRepository
{
    Task CreateAsync(RefreshToken RefreshToken);
    Task<List<RefreshToken>> GetAllActiveTokensByUserId(Guid UserId);
    Task<RefreshToken> GetByTokenHashAsync(string Token);
    Task RevokeAsync(RefreshToken Token);
    Task DeleteExpiredTokensAsync();
    Task<bool> UserHasActiveTokens(Guid UserId);
}
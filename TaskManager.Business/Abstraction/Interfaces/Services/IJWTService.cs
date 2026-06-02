using TaskManager.Domain.Models;

namespace TaskManager.Business.Abstraction.Interfaces.Services;

public interface IJWTService
{
    string GenerateAccessToken(User User);
    string GenerateRefreshToken();
}
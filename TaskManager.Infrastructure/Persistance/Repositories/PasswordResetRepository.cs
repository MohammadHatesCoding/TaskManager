using Microsoft.EntityFrameworkCore;
using TaskManager.Business.Abstraction.Interfaces.Repositories;
using TaskManager.Domain.Models;
using TaskManager.Infrastructure.Persistance.Context;

namespace TaskManager.Infrastructure.Persistance.Repositories;

public class PasswordResetTokenRepository : IPasswordResetTokenRepository
{
    private readonly ApplicationDbContext _context;
    public PasswordResetTokenRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(PasswordResetToken PasswordResetToken)
    {
        await _context.Set<PasswordResetToken>().AddAsync(PasswordResetToken);
    }

    public async Task<PasswordResetToken> GetByTokenHashAsync(string Token)
    {
        return await _context.Set<PasswordResetToken>()
            .FirstOrDefaultAsync(x => x.Token == Token);
    }

}

using Microsoft.EntityFrameworkCore;
using TaskManager.Business.Abstraction.Interfaces.Repositories;
using TaskManager.Domain.Models;
using TaskManager.Infrastructure.Persistance.Context;

namespace TaskManager.Infrastructure.Persistance.Repositories;

public class UserRoleRepository : IUserRoleRepository
{
    private readonly ApplicationDbContext _context;
    public UserRoleRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task CreateAsync(Guid UserId, int RoleId)
    {
        var userRole = new UserRole
        {
            UserId = UserId,
            RoleId = RoleId
        };

        await _context.Set<UserRole>().AddAsync(userRole);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid UserId, int RoleId)
    {
        var userRole = await _context.Set<UserRole>().FirstOrDefaultAsync(x => x.UserId == UserId && x.RoleId == RoleId);

        _context.Set<UserRole>().Remove(userRole);

        await _context.SaveChangesAsync();
    }

    public async Task<List<UserRole>> GetAllAsync()
    {
        var userRoles = await _context.Set<UserRole>().ToListAsync();
        return userRoles;
    }

    public async Task<List<UserRole>> GetUserRolesByUserIdAsync(Guid userId)
    {
        return await _context.Set<UserRole>()
            .Where(ur => ur.UserId == userId)
            .ToListAsync();
    }

    public async Task<List<UserRole>> GetUserRolesByRoleIdAsync(int roleId)
    {
        return await _context.Set<UserRole>()
            .Where(ur => ur.RoleId == roleId)
            .ToListAsync();
    }
}

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskManager.Business.Abstraction.Interfaces.Repositories;
using TaskManager.Domain.Models;
using TaskManager.Infrastructure.Persistance.Context;

namespace TaskManager.Infrastructure.Persistance.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task CreateAsync(User user)
    {
        await _context.Set<User>().AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid Id)
    {
        var user = await _context.Set<User>().FirstOrDefaultAsync(x => x.Id == Id);
        if (user is null)
            return;
        user.IsDeleted = true;
        await _context.SaveChangesAsync();
    }

    public async Task<bool> Exists(Expression<Func<User, bool>> predicate)
    {
        return await _context.Set<User>().AnyAsync(predicate);
    }

    public async Task<User> Find(Expression<Func<User, bool>> predicate)
    {
        return await _context.Set<User>().Include(x => x.UserRoles).ThenInclude(x => x.Role).FirstOrDefaultAsync(predicate);
    }

    public async Task<List<User>> GetAllAsync()
    {
        var users = await _context.Set<User>().Where(x => !x.IsDeleted).ToListAsync();
        return users;
    }

    public Task<User> GetByIdAsync(Guid id)
    {
        var user = _context.Set<User>().FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        return user;
    }

    public async Task UpdateAsync(User user)
    {
        _context.Set<User>().Attach(user);
        _context.Entry(user).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}

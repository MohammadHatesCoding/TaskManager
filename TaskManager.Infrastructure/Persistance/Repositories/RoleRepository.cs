using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskManager.Business.Abstraction.Interfaces.Repositories;
using TaskManager.Domain.Models;
using TaskManager.Infrastructure.Persistance.Context;
using TaskManager.Infrastructure.Persistance.Repositories.Base;

namespace TaskManager.Infrastructure.Persistance.Repositories;

internal class RoleRepository : BaseRepository<Role>, IRoleRepository
{
    private readonly ApplicationDbContext _context;
    public RoleRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Role> Find(Expression<Func<Role, bool>> predicate)
    {
        return await _context.Set<Role>().Include(x => x.UserRoles).ThenInclude(x => x.User).FirstOrDefaultAsync(predicate);
    }
}
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
}

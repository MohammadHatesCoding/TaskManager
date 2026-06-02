using TaskManager.Business.Abstraction.Interfaces.Repositories;
using TaskManager.Domain.Models;
using TaskManager.Infrastructure.Persistance.Context;
using TaskManager.Infrastructure.Persistance.Repositories.Base;

namespace TaskManager.Infrastructure.Persistance.Repositories;

internal class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
{
    private readonly ApplicationDbContext _context;
    public DepartmentRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}

using TaskManager.Business.Abstraction.Interfaces.Repositories;
using TaskManager.Domain.Models;
using TaskManager.Infrastructure.Persistance.Context;
using TaskManager.Infrastructure.Persistance.Repositories.Base;

namespace TaskManager.Infrastructure.Persistance.Repositories;

internal class AssignmentEmployeeRepository : BaseRepository<AssignmentEmployee>, IAssignmentEmployeeRepository
{
    private readonly ApplicationDbContext _context;
    public AssignmentEmployeeRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}

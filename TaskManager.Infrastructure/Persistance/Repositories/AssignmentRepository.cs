using TaskManager.Business.Abstraction.Interfaces.Repositories;
using TaskManager.Domain.Models;
using TaskManager.Infrastructure.Persistance.Context;
using TaskManager.Infrastructure.Persistance.Repositories.Base;

namespace TaskManager.Infrastructure.Persistance.Repositories;

public class AssignmentRepository : BaseRepository<Assignment>, IAssignmentRepository
{
    private readonly ApplicationDbContext _context;
    public AssignmentRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}

using Microsoft.EntityFrameworkCore;
using TaskManager.Business.Abstraction.Interfaces.Repositories;
using TaskManager.Business.Features.CompanyFeatures.Queries;
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

    public async Task<List<Department>> GetAllDepartmentdByCompanyId(int CompanyId)
    {
        return await _context.Departments.Where(x => x.CompanyId == CompanyId).ToListAsync();
    }
}

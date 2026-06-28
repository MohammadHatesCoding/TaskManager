using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskManager.Business.Abstraction.Interfaces.Repositories;
using TaskManager.Domain.Models;
using TaskManager.Infrastructure.Persistance.Context;
using TaskManager.Infrastructure.Persistance.Repositories.Base;

namespace TaskManager.Infrastructure.Persistance.Repositories;

internal class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
{
    private readonly ApplicationDbContext _context;
    public EmployeeRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Employee> find(Expression<Func<Employee, bool>> predicate)
    {
        return await _context.Employees.FirstOrDefaultAsync(predicate);
    }

    public async Task<List<Employee>> GetEmployeesByDepartmentId(int DepartmentId)
    {
        return await _context.Employees.Where(x => x.DepartmentId == DepartmentId).ToListAsync();
    }
}
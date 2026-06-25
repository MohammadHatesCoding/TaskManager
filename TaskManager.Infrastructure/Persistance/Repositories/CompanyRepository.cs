using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskManager.Business.Abstraction.Interfaces.Repositories;
using TaskManager.Domain.Models;
using TaskManager.Infrastructure.Persistance.Context;
using TaskManager.Infrastructure.Persistance.Repositories.Base;

namespace TaskManager.Infrastructure.Persistance.Repositories;

public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
{
    private readonly ApplicationDbContext _context;
    public CompanyRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<bool> Exists(Expression<Func<Company, bool>> predicate)
    {
        return await _context.Set<Company>().AnyAsync(predicate);
    }
}

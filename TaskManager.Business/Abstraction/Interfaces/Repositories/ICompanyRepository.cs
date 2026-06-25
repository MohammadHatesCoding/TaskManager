using System.Linq.Expressions;
using TaskManager.Business.Abstraction.Interfaces.Repositories.Base;
using TaskManager.Domain.Models;

namespace TaskManager.Business.Abstraction.Interfaces.Repositories;

public interface ICompanyRepository : IBaseRepository<Company>
{
    Task<bool> Exists(Expression<Func<Company, bool>> predicate);
}
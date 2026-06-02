using System.Linq.Expressions;
using TaskManager.Domain.Models;

namespace TaskManager.Business.Abstraction.Interfaces.Repositories;

public interface IUserRepository
{
    Task<User> GetByIdAsync(Guid Id);
    Task<List<User>> GetAllAsync();
    Task CreateAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(Guid Id);
    Task<bool> Exists(Expression<Func<User, bool>> predicate);
    Task<User> Find(Expression<Func<User, bool>> predicate);
}

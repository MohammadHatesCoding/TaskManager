using System.Linq.Expressions;
using TaskManager.Business.Abstraction.Interfaces.Repositories.Base;
using TaskManager.Domain.Models;

namespace TaskManager.Business.Abstraction.Interfaces.Repositories;

public interface IEmployeeRepository : IBaseRepository<Employee>
{
    Task<List<Employee>> GetEmployeesByDepartmentId(int DepartmentId);

    Task<Employee> find(Expression<Func<Employee, bool>> predicate);
}
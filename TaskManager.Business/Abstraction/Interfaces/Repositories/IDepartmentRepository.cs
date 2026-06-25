using TaskManager.Business.Abstraction.Interfaces.Repositories.Base;
using TaskManager.Business.Features.CompanyFeatures.Queries;
using TaskManager.Domain.Models;

namespace TaskManager.Business.Abstraction.Interfaces.Repositories;

public interface IDepartmentRepository : IBaseRepository<Department>
{
    Task<List<Department>> GetAllDepartmentdByCompanyId(int CompanyId);
}
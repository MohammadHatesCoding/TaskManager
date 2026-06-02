using TaskManager.Domain.Models.BaseModel;

namespace TaskManager.Business.Abstraction.Interfaces.Repositories.Base;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(int Id);
    Task<List<T>> GetAllAsync();
    Task CreateAsync(T model);
    Task UpdateAsync(T model);
    Task DeleteAsync(int id); //soft delete
}
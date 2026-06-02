using TaskManager.Domain.Models;

namespace TaskManager.Business.Abstraction.Interfaces.Repositories;

public interface IAttachmentRepository
{
    Task<Attachment> GetByIdAsync(Guid Id);
    Task<List<Attachment>> GetAllAsync();
    Task CreateAsync(Attachment model);
    Task DeleteAsync(Guid id); //soft delete
}

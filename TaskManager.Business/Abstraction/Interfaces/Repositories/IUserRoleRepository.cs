using TaskManager.Domain.Models;

namespace TaskManager.Business.Abstraction.Interfaces.Repositories;

public interface IUserRoleRepository
{
    Task<List<UserRole>> GetAllAsync();
    Task CreateAsync(Guid UserId, int RoleId);
    Task DeleteAsync(Guid UserId, int RoleId);
    Task<List<UserRole>> GetUserRolesByUserIdAsync(Guid userId);
    Task<List<UserRole>> GetUserRolesByRoleIdAsync(int roleId);
}
namespace TaskManager.Business.Abstraction.Interfaces.Services;

public interface ICurrentUserService
{
    Guid? UserId { get; }
    string? UserName { get; }
    string? Email { get; }
}
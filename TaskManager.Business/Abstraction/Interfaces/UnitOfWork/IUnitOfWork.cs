using TaskManager.Business.Abstraction.Interfaces.Repositories;

namespace TaskManager.Business.Abstraction.Interfaces.UnitOfWork;

public interface IUnitOfWork
{
    IAssignmentEmployeeRepository AssignmentEmployeeRepository { get; }
    IAssignmentRepository AssignmentRepository { get; }
    IAttachmentRepository AttachmentRepository { get; }
    ICommentRepository CommentRepository { get; }
    ICompanyRepository CompanyRepository { get; }
    IDepartmentRepository DepartmentRepository { get; }
    IEmployeeRepository EmployeeRepository { get; }
    IProjectRepository ProjectRepository { get; }
    IProjectEmployeeRepository ProjectEmployeeRepository { get; }
    IRoleRepository RoleRepository { get; }
    IUserRepository UserRepository { get; }
    IUserRoleRepository UserRoleRepository { get; }
    IRefreshTokenRepository RefreshTokenRepository { get; }
    IPasswordResetTokenRepository PasswordResetTokenRepository { get; }
    IReadDbConnection ReadDbConnection { get; }
    IWriteDbConnection WriteDbConnection { get; }

    Task CommitAsync(CancellationToken cancellationToken);
}
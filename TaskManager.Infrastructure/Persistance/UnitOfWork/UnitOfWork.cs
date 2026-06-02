using TaskManager.Business.Abstraction.Interfaces.Repositories;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;
using TaskManager.Infrastructure.Persistance.Context;

namespace TaskManager.Infrastructure.Persistance.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    #region Repos
    private readonly ApplicationDbContext _context;
    private readonly IAssignmentEmployeeRepository _assignmentEmployeeRepository;
    private readonly IAssignmentRepository _assignmentRepository;
    private readonly IAttachmentRepository _attachmentRepository;
    private readonly ICommentRepository _commentRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IProjectRepository _projectRepository;
    private readonly IProjectEmployeeRepository _projectEmployeeRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IReadDbConnection _readDbConnection;
    private readonly IWriteDbConnection _writeDbConnection;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IPasswordResetTokenRepository _passwordResetTokenRepository;
    #endregion

    public UnitOfWork(ApplicationDbContext context, IAssignmentEmployeeRepository assignmentEmployeeRepository, IAssignmentRepository assignmentRepository,
        IAttachmentRepository attachmentRepository, ICommentRepository commentRepository, ICompanyRepository companyRepository, IDepartmentRepository departmentRepository,
        IEmployeeRepository employeeRepository, IProjectRepository projectRepository, IProjectEmployeeRepository projectEmployeeRepository, IRoleRepository roleRepository,
        IUserRepository userRepository, IUserRoleRepository userRoleRepository, IReadDbConnection readDbConnection, IWriteDbConnection writeDbConnection,
        IRefreshTokenRepository refreshTokenRepository, IPasswordResetTokenRepository passwordResetTokenRepository)
    {
        _context = context;
        _assignmentEmployeeRepository = assignmentEmployeeRepository;
        _assignmentRepository = assignmentRepository;
        _attachmentRepository = attachmentRepository;
        _commentRepository = commentRepository;
        _companyRepository = companyRepository;
        _departmentRepository = departmentRepository;
        _employeeRepository = employeeRepository;
        _projectRepository = projectRepository;
        _projectEmployeeRepository = projectEmployeeRepository;
        _roleRepository = roleRepository;
        _userRepository = userRepository;
        _userRoleRepository = userRoleRepository;
        _readDbConnection = readDbConnection;
        _writeDbConnection = writeDbConnection;
        _refreshTokenRepository = refreshTokenRepository;
        _passwordResetTokenRepository = passwordResetTokenRepository;
    }
    public IAssignmentEmployeeRepository AssignmentEmployeeRepository => _assignmentEmployeeRepository;
    public IAssignmentRepository AssignmentRepository => _assignmentRepository;
    public IAttachmentRepository AttachmentRepository => _attachmentRepository;
    public ICommentRepository CommentRepository => _commentRepository;
    public ICompanyRepository CompanyRepository => _companyRepository;
    public IDepartmentRepository DepartmentRepository => _departmentRepository;
    public IEmployeeRepository EmployeeRepository => _employeeRepository;
    public IProjectRepository ProjectRepository => _projectRepository;
    public IProjectEmployeeRepository ProjectEmployeeRepository => _projectEmployeeRepository;
    public IRoleRepository RoleRepository => _roleRepository;
    public IUserRepository UserRepository => _userRepository;
    public IUserRoleRepository UserRoleRepository => _userRoleRepository;
    public IReadDbConnection ReadDbConnection => _readDbConnection;
    public IWriteDbConnection WriteDbConnection => _writeDbConnection;
    public IRefreshTokenRepository RefreshTokenRepository => _refreshTokenRepository;
    public IPasswordResetTokenRepository PasswordResetTokenRepository => _passwordResetTokenRepository;

    public async Task CommitAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}

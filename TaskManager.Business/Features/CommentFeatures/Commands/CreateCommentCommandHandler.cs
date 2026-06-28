using AutoMapper;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.Services;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;
using TaskManager.Domain.Models;

namespace TaskManager.Business.Features.CommentFeatures.Commands;

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, CreateCommentResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentCompanyService _currentCompanyService;
    private readonly ICurrentUserService _currentUserService;
    public CreateCommentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ICurrentCompanyService currentCompanyService, ICurrentUserService currentUserService)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _currentCompanyService = currentCompanyService;
        _currentUserService = currentUserService;
    }

    public async Task<CreateCommentResponse> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            int companyId = _currentCompanyService.CompanyId;

            Guid userId = _currentUserService.UserId.Value;

            var employee = await _unitOfWork.EmployeeRepository
                .find(x => x.CompanyId == companyId && x.UserId == userId
                    && x.IsActive
                    && !x.IsBlocked
                    && !x.IsDeleted);

            if(!employee.AssignmentEmployees.Any(x => x.AssignmentId == request.command.AssignmentId))
                throw new Exception(message: "Employee cant comment on this task");

            var comment = _mapper.Map<Comment>(request.command);

            comment.EmployeeId = employee.Id;

            await _unitOfWork.CommentRepository.CreateAsync(comment);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new CreateCommentResponse(Id: comment.Id);
        }
        catch (Exception ex) 
        {
            throw new Exception(message: ex.Message);
        }
    }
}
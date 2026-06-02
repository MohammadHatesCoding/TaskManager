using AutoMapper;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;

namespace TaskManager.Business.Features.UserRoleFeatures.Commands;

public class DeleteUserRoleCommandHandler : IRequestHandler<DeleteUserRoleCommand, DeleteUserRoleResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteUserRoleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<DeleteUserRoleResponse> Handle(DeleteUserRoleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _unitOfWork.UserRoleRepository.DeleteAsync(request.command.UserId, request.command.RoleId);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new DeleteUserRoleResponse(Success: true);
        }
        catch (Exception ex) 
        {
            throw new Exception(message: ex.Message);
        }
    }
}
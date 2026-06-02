using AutoMapper;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;
using TaskManager.Domain.Models;

namespace TaskManager.Business.Features.UserRoleFeatures.Commands;

public class CreateUserRoleCommandHandler : IRequestHandler<CreateUserRoleCommand, CreateUserRoleResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public CreateUserRoleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateUserRoleResponse> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _unitOfWork.UserRoleRepository.CreateAsync(request.command.UserId, request.command.RoleId);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new CreateUserRoleResponse(Success: true);
        }
        catch (Exception ex) 
        {
            throw new Exception(message: ex.Message);
        }
    }
}
using AutoMapper;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;
using TaskManager.Domain.Models;
using TaskManager.Shared.Enums;

namespace TaskManager.Business.Features.UserFeatures.Commands;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (await _unitOfWork.UserRepository.Exists(x => x.Username == request.command.Username))
                throw new Exception(message: "نام کاربری موجود نیست!");

            var user = await _unitOfWork.UserRepository.GetByIdAsync(request.command.Id);

            _mapper.Map(request.command, user);

            var userRole = (await _unitOfWork.UserRoleRepository.GetUserRolesByUserIdAsync(user.Id))
                .Where(x => x.RoleId != ((int)Roles.User)).ToList();

            foreach (var item in userRole)
            {
                await _unitOfWork.UserRoleRepository.DeleteAsync(item.UserId, item.RoleId);
            }

            foreach (var item in request.command.UserRoles)
            {
                await _unitOfWork.UserRoleRepository.CreateAsync(item.UserId, item.RoleId);   
            }

            await _unitOfWork.CommitAsync(cancellationToken);

            return new UpdateUserResponse(Success: true);
        }
        catch (Exception ex) 
        {
            throw new Exception(message: ex.Message);
        }
    }
}
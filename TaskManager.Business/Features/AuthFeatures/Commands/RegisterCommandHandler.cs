using AutoMapper;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;
using TaskManager.Domain.Models;

namespace TaskManager.Business.Features.AuthFeatures.Commands;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RegisterCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (await _unitOfWork.UserRepository.Exists(x => x.Email == request.command.Email || x.NationalCode == request.command.NationalCode))
                throw new Exception(message: "ایمیل قبلا در سامانه ثبت شده است!"); 

            if (await _unitOfWork.UserRepository.Exists(x => x.NationalCode == request.command.NationalCode))
                throw new Exception(message: "کاربر قبلا در سامانه ثبت شده است!");

            if(await _unitOfWork.UserRepository.Exists(x => x.Username.ToLower() == request.command.Username.ToLower()))
                throw new Exception(message: "نام کاربری موجود نیست!");

            var user = _mapper.Map<User>(request.command);

            await _unitOfWork.UserRepository.CreateAsync(user);

            var role = await _unitOfWork.RoleRepository.Find(x => x.Title == "User");

            await _unitOfWork.UserRoleRepository.CreateAsync(user.Id, role.Id);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new RegisterResponse(Id: user.Id);
        }
        catch (Exception ex)
        {
            throw new Exception(message: ex.Message);
        }
    }
}
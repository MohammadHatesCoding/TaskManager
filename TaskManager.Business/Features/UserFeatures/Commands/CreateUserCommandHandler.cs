using AutoMapper;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.Services;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;
using TaskManager.Domain.Models;
using TaskManager.Shared.Enums;

namespace TaskManager.Business.Features.UserFeatures.Commands;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordService _passwordService;
    public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IPasswordService passwordService)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _passwordService = passwordService;
    }

    public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (await _unitOfWork.UserRepository.Exists(x => x.Email == request.command.Email || x.NationalCode == request.command.NationalCode))
                throw new Exception(message: "ایمیل قبلا در سامانه ثبت شده است!");

            if (await _unitOfWork.UserRepository.Exists(x => x.NationalCode == request.command.NationalCode))
                throw new Exception(message: "کاربر قبلا در سامانه ثبت شده است!");

            var user = _mapper.Map<User>(request.command);

            user.Username = user.Email ?? user.NationalCode;

            await _unitOfWork.UserRepository.CreateAsync(user);

            await _unitOfWork.CommitAsync(cancellationToken);

            var role = await _unitOfWork.RoleRepository.Find(x => x.Title == Roles.User.ToString());

            await _unitOfWork.UserRoleRepository.CreateAsync(user.Id, ((int)Roles.User));

            await _unitOfWork.CommitAsync(cancellationToken);

            return new CreateUserResponse(Success: true);
        }
        catch (Exception ex) 
        {
            throw new Exception(message: ex.Message);
        }
    }
}
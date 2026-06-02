using AutoMapper;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;
using TaskManager.Business.Features.UserFeatures.Commands;
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

            if(await _unitOfWork.UserRepository.Exists(x => x.Username.Equals(request.command.Username, StringComparison.OrdinalIgnoreCase)))
                throw new Exception(message: "نام کاربری موجود نیست!");

            var user = _mapper.Map<User>(request.command);

            await _unitOfWork.UserRepository.CreateAsync(user);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new RegisterResponse(Success: true);
        }
        catch (Exception ex)
        {
            throw new Exception(message: ex.Message);
        }
    }
}

using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.Services;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;

namespace TaskManager.Business.Features.AuthFeatures.Commands;

public class CreatePasswordCommandHandler : IRequestHandler<CreatePasswordCommand, CreatePasswordResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordService _passwordService;
    public CreatePasswordCommandHandler(IUnitOfWork unitOfWork, IPasswordService passwordService)
    {
        _unitOfWork = unitOfWork;
        _passwordService = passwordService;
    }
    public async Task<CreatePasswordResponse> Handle(CreatePasswordCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var passwordHash = _passwordService.HashPassword(request.command.Password);

            var user = await _unitOfWork.UserRepository.Find(x => x.Username.Equals(request.command.Username));

            user.PasswordHash = passwordHash;

            await _unitOfWork.CommitAsync(cancellationToken);

            return new CreatePasswordResponse(Success: true);
        }
        catch (Exception ex)
        {
            throw new Exception(message: ex.Message);
        }
    }
}
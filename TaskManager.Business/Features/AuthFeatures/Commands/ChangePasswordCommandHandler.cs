using System.ComponentModel.DataAnnotations;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.Services;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;

namespace TaskManager.Business.Features.AuthFeatures.Commands;

public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ChangePasswordResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordService _passwordService;
    private readonly ICurrentUserService _currentUserService;
    public ChangePasswordCommandHandler(IUnitOfWork unitOfWork, IPasswordService passwordService, ICurrentUserService currentUserService)
    {
        _unitOfWork = unitOfWork;
        _passwordService = passwordService;
        _currentUserService = currentUserService;
    }
    public async Task<ChangePasswordResponse> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (!request.command.NewPassword.Equals(request.command.ConfirmNewPassword))
                throw new ValidationException("Passwords dont match.");

            var user = await _unitOfWork.UserRepository.GetByIdAsync(_currentUserService.UserId.Value);

            if (user is null || !user.IsActive)
                throw new UnauthorizedAccessException();

            var IsValid = _passwordService.VerifyPassword(user.PasswordHash, request.command.OldPassword);

            if (!IsValid)
                throw new UnauthorizedAccessException();

            var newPasswordHash = _passwordService.HashPassword(request.command.NewPassword);

            user.PasswordHash = newPasswordHash;

            var oldRefreshTokens = await _unitOfWork.RefreshTokenRepository.GetAllActiveTokensByUserId(user.Id);

            foreach (var oldToken in oldRefreshTokens)
                oldToken.IsRevoked = true;

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ChangePasswordResponse(Success: true);
        }
        catch (Exception ex)
        {
            throw new Exception(message: ex.Message);
        }
    }
}
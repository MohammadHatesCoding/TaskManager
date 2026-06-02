using System.ComponentModel.DataAnnotations;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.Services;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;

namespace TaskManager.Business.Features.AuthFeatures.Commands;

internal class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, ResetPasswordResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordService _passwordService;
    private readonly ITokenService _tokenService;
    public ResetPasswordCommandHandler(IUnitOfWork unitOfWork, IPasswordService passwordService, ITokenService tokenService)
    {
        _unitOfWork = unitOfWork;
        _passwordService = passwordService;
        _tokenService = tokenService;
    }
    public async Task<ResetPasswordResponse> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (!request.command.Password.Equals(request.command.ConfirmPassword))
                throw new ValidationException("Passwords dont match.");

            var hashedInputPasswordResetToken = _tokenService.Hash(request.command.ResetPasswordToken);

            var passwordResetTokenEntity = await _unitOfWork.PasswordResetTokenRepository.GetByTokenHashAsync(hashedInputPasswordResetToken);

            if (passwordResetTokenEntity is null || 
                passwordResetTokenEntity.IsUsed || 
                passwordResetTokenEntity.ExpiresAt < DateTime.UtcNow)
                throw new UnauthorizedAccessException();

            if (_tokenService.Verify(request.command.ResetPasswordToken, passwordResetTokenEntity.Token))
                throw new UnauthorizedAccessException();

            var user = await _unitOfWork.UserRepository.GetByIdAsync(passwordResetTokenEntity.UserId);

            user.PasswordHash = _passwordService.HashPassword(request.command.Password);

            var oldRefreshTokens = await _unitOfWork.RefreshTokenRepository.GetAllActiveTokensByUserId(user.Id);

            foreach (var refreshToken in oldRefreshTokens)
            {
                refreshToken.IsRevoked = true;
            }

            passwordResetTokenEntity.IsUsed = true;

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ResetPasswordResponse(Success: true);
        }
        catch (Exception ex)
        {
            throw new Exception(message: ex.Message);
        }
    }
}
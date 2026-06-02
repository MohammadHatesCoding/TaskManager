using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.Services;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;
using TaskManager.Domain.Models;

namespace TaskManager.Business.Features.AuthFeatures.Commands;

public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, ForgotPasswordResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEmailService _emailService;
    private readonly IPasswordService _passwordService;
    private readonly ITokenService _tokenService;
    public ForgotPasswordCommandHandler(IUnitOfWork unitOfWork, IEmailService emailService, IPasswordService passwordService, ITokenService tokenService)
    {
        _unitOfWork = unitOfWork;
        _emailService = emailService;
        _passwordService = passwordService;
        _tokenService = tokenService;
    }
    public async Task<ForgotPasswordResponse> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _unitOfWork.UserRepository
                .Find(x => x.Username.Equals(request.command.Username, StringComparison.OrdinalIgnoreCase));

            if (user is null)
                throw new UnauthorizedAccessException("نام کاربری یافت نشد!");

            string rawPasswordResetToken = _passwordService.GeneratePasswordResetToken();

            string hashedPasswordToken = _tokenService.Hash(rawPasswordResetToken);

            var passwordResetTokenEntity = new PasswordResetToken
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                Token = hashedPasswordToken
            };

            await _unitOfWork.PasswordResetTokenRepository.CreateAsync(passwordResetTokenEntity);

            await _unitOfWork.CommitAsync(cancellationToken);

            string ResetLink = $"https://frontend.com/reset-password?ResetPasswordToken={rawPasswordResetToken}";

            _emailService.SendEmail(to: user.Email, subject: "Password reset request", body: $"برای تنظیم مجدد Password خود وارد لینک زیر شوید :\n{ResetLink}");

            return new ForgotPasswordResponse(Success: true);
        }
        catch (Exception ex) 
        {
            throw new Exception();
        }
    }
}
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.Services;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;

namespace TaskManager.Business.Features.UserFeatures.Commands;

public class HasPasswordCommandHandler : IRequestHandler<HasPasswordCommand, HasPasswordResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEmailService _emailService;
    private readonly IOTPService _otpService;
    public HasPasswordCommandHandler(IUnitOfWork unitOfWork, IEmailService emailService, IOTPService otpService)
    {
        _unitOfWork = unitOfWork;
        _emailService = emailService;
        _otpService = otpService;
    }

    public async Task<HasPasswordResponse> Handle(HasPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.UserRepository.Find(x => x.Username == request.command.Username);

        if (user is null)
            throw new Exception();

        if (user.PasswordHash == string.Empty)
        {
            var otp = _otpService.GenerateOtpAsync();
            user.OtpHash = otp.hashedOtp;
            user.OTPDuration = DateTime.Now.AddMinutes(5);
            await _unitOfWork.CommitAsync(cancellationToken);
            _emailService.SendEmail(user.Email, "احراز هویت", $"جناب آقای {user.Name} کد زیر محرمانه میباشد لطفا آن را به کس دیگری ندهید :\n{otp.otp}");

            return new HasPasswordResponse(Success: false);
        }

        return new HasPasswordResponse(Success: true);
    }
}
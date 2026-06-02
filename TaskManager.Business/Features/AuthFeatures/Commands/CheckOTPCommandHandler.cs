using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.Services;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;

namespace TaskManager.Business.Features.AuthFeatures.Commands;

public class CheckOTPCommandHandler : IRequestHandler<CheckOTPCommand, CheckOTPResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOTPService _otpService;
    public CheckOTPCommandHandler(IUnitOfWork unitOfWork, IOTPService otpService)
    {
        _unitOfWork = unitOfWork;
        _otpService = otpService;
    }
    public async Task<CheckOTPResponse> Handle(CheckOTPCommand request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.UserRepository.Find(x => x.Username == request.command.username);

        bool check = _otpService.VerifyOtpAsync(user.OtpHash, request.command.otp);

        if (check)
        {
            user.OtpHash = string.Empty;
            user.OTPDuration = null;
            return new CheckOTPResponse(Success: true);
        }

        return new CheckOTPResponse(Success: false);
    }
}

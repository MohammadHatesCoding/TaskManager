using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.Services;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;
using TaskManager.Domain.Models;

namespace TaskManager.Business.Features.AuthFeatures.Commands;

public class LogoutCommandHandler : IRequestHandler<LogoutCommand, LogoutResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;
    public LogoutCommandHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
    {
        _unitOfWork = unitOfWork;
        _currentUserService = currentUserService;
    }
    public async Task<LogoutResponse> Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var activeRefreshTokens = await _unitOfWork.RefreshTokenRepository.GetAllActiveTokensByUserId(_currentUserService.UserId.Value);

            foreach (var oldToken in activeRefreshTokens)
                oldToken.IsRevoked = true;

            await _unitOfWork.CommitAsync(cancellationToken);

            return new LogoutResponse(Success: true);

        }
        catch (Exception ex)
        {
            throw new Exception(message: ex.Message);
        }
    }
}

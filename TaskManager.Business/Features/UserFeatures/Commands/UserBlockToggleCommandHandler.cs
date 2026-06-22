using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;

namespace TaskManager.Business.Features.UserFeatures.Commands;

public class UserBlockToggleCommandHandler : IRequestHandler<UserBlockToggleCommand, UserBlockToggleResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    public UserBlockToggleCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<UserBlockToggleResponse> Handle(UserBlockToggleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(request.command.UserId);

            user.IsBlocked = !user.IsBlocked;

            await _unitOfWork.CommitAsync(cancellationToken);

            return new UserBlockToggleResponse(Success: true);
        }
        catch(Exception ex)
        {
            throw new Exception(message: ex.Message); ;
        }
    }
}

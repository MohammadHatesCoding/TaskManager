using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;

namespace TaskManager.Business.Features.UserFeatures.Commands;

public class ToggleUserActivityCommandHandler : IRequestHandler<ToggleUserActivityCommand, ToggleUserActivityResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    public ToggleUserActivityCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<ToggleUserActivityResponse> Handle(ToggleUserActivityCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(request.command.UserId);

            user.IsActive = !user.IsActive;

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ToggleUserActivityResponse(Success: true);
        }
        catch(Exception ex)
        {
            throw new Exception(message: ex.Message); ;
        }
    }
}

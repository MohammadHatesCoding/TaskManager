using AutoMapper;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;
using TaskManager.Domain.Models;

namespace TaskManager.Business.Features.UserFeatures.Commands;

public record UpdateMyProfileCommandHandler : IRequestHandler<UpdateMyProfileCommand, UpdateMyProfileResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public UpdateMyProfileCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UpdateMyProfileResponse> Handle(UpdateMyProfileCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (await _unitOfWork.UserRepository.Exists(x => x.Username == request.command.Username))
                throw new Exception(message: "نام کاربری موجود نیست!");

            var user = await _unitOfWork.UserRepository.GetByIdAsync(request.command.Id);

            user = _mapper.Map<User>(request.command);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new UpdateMyProfileResponse(Success: true);
        }
        catch (Exception ex)
        {
            throw new Exception(message: ex.Message);
        }
    }
}

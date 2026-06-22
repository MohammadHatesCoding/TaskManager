using AutoMapper;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.Services;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;

namespace TaskManager.Business.Features.UserFeatures.Queries;

public class GetProfileDetailsQueryHandler : IRequestHandler<GetProfileDetailsQuery, GetProfileDetailsResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserService _currentUserService;
    private readonly IMapper _mapper;
    public GetProfileDetailsQueryHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _currentUserService = currentUserService;
        _mapper = mapper;
    }

    public async Task<GetProfileDetailsResponse> Handle(GetProfileDetailsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var model = await _unitOfWork.UserRepository.GetByIdAsync(_currentUserService.UserId.Value);

            var user = _mapper.Map<GetProfileDetailsResponse>(model);            

            return user;
        }
        catch (Exception ex)
        {
            throw new Exception(message: ex.Message);
        }
    }
}
using AutoMapper;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;
using TaskManager.Business.Features.UserRoleFeatures.Queries;

namespace TaskManager.Business.Features.UserFeatures.Queries;

public class GetProfileDetailsQueryHandler : IRequestHandler<GetProfileDetailsQuery, GetProfileDetailsResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetProfileDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetProfileDetailsResponse> Handle(GetProfileDetailsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var model = await _unitOfWork.UserRepository.GetByIdAsync(request.query.Id);

            var user = _mapper.Map<GetProfileDetailsResponse>(model);            

            return user;
        }
        catch (Exception ex)
        {
            throw new Exception(message: ex.Message);
        }
    }
}
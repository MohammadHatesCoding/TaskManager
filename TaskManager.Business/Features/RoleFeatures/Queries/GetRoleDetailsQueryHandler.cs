using AutoMapper;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;

namespace TaskManager.Business.Features.RoleFeatures.Queries;

public class GetRoleDetailsQueryHandler : IRequestHandler<GetRoleDetailsQuery, GetRoleDetailsResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetRoleDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetRoleDetailsResponse> Handle(GetRoleDetailsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var model = await _unitOfWork.RoleRepository.GetByIdAsync(request.query.RoleId);

            var role = _mapper.Map<GetRoleDetailsResponse>(model);

            return role;
        }
        catch (Exception ex)
        {
            throw new Exception(message: ex.Message);
        }
    }
}
using AutoMapper;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;

namespace TaskManager.Business.Features.UserRoleFeatures.Queries;

public class GetUserRolesByRoleIdQueryHandler : IRequestHandler<GetUserRolesByRoleIdQuery, List<GetUserRolesByRoleIdResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetUserRolesByRoleIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<GetUserRolesByRoleIdResponse>> Handle(GetUserRolesByRoleIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var models = await _unitOfWork.UserRoleRepository.GetUserRolesByRoleIdAsync(request.query.RoleId);

            var userRoles = _mapper.Map<List<GetUserRolesByRoleIdResponse>>(models);

            return userRoles;
        }
        catch (Exception ex)
        {
            throw new Exception(message: ex.Message);
        }
    }
}
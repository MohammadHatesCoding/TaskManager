using AutoMapper;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;

namespace TaskManager.Business.Features.UserRoleFeatures.Queries;

public class GetUserRolesByUserIdQueryHandler : IRequestHandler<GetUserRolesByUserIdQuery, List<GetUserRolesByUserIdResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetUserRolesByUserIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<GetUserRolesByUserIdResponse>> Handle(GetUserRolesByUserIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var models = await _unitOfWork.UserRoleRepository.GetUserRolesByUserIdAsync(request.query.UserId);

            var userRoles = _mapper.Map<List<GetUserRolesByUserIdResponse>>(models);

            return userRoles;
        }
        catch (Exception ex)
        {
            throw new Exception(message: ex.Message);
        }
    }
}
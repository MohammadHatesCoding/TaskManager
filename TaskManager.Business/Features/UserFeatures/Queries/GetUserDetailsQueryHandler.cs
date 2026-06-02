using AutoMapper;
using TaskManager.Business.Abstraction.Data;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;
using TaskManager.Business.Features.UserRoleFeatures.Queries;

namespace TaskManager.Business.Features.UserFeatures.Queries;

public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, GetUserDetailsResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetUserDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetUserDetailsResponse> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var model = await _unitOfWork.UserRepository.GetByIdAsync(request.query.Id);

            var param = new CustomDynamicParameters();

            var userRoles = await _unitOfWork.ReadDbConnection
                .QueryAsync<GetUserRoleDetailsByUserIdResponse>("", param, null, System.Data.CommandType.StoredProcedure);
                
            var user = _mapper.Map<GetUserDetailsResponse>(model) with { UserRoles = userRoles.ToList()};            

            return user;
        }
        catch (Exception ex)
        {
            throw new Exception(message: ex.Message);
        }
    }
}
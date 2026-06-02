using AutoMapper;
using TaskManager.Business.Abstraction.Data;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;
using TaskManager.Business.Features.DepartmentFeatures.Queries;

namespace TaskManager.Business.Features.UserRoleFeatures.Queries;

public class GetAllUserRolesQueryHandler : IRequestHandler<GetAllUserRolesQuery, List<GetAllUserRolesResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetAllUserRolesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<GetAllUserRolesResponse>> Handle(GetAllUserRolesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var parameters = new CustomDynamicParameters();

            var userRoles = await _unitOfWork.ReadDbConnection.QueryAsync<GetAllUserRolesResponse>("", parameters, null, System.Data.CommandType.StoredProcedure);

            //var roles = _mapper.Map<List<GetAllCompaniesResponse>>(models);

            return userRoles.ToList();
        }
        catch (Exception ex)
        {
            throw new Exception(message: ex.Message);
        }
    }
}
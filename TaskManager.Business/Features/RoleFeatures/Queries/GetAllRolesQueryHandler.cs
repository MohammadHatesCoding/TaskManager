using AutoMapper;
using TaskManager.Business.Abstraction.Data;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;
using TaskManager.Business.Features.DepartmentFeatures.Queries;

namespace TaskManager.Business.Features.RoleFeatures.Queries;

public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, List<GetAllRolesResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetAllRolesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<GetAllRolesResponse>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var parameters = new CustomDynamicParameters();

            var roles = await _unitOfWork.ReadDbConnection.QueryAsync<GetAllRolesResponse>("", parameters, null, System.Data.CommandType.StoredProcedure);

            //var roles = _mapper.Map<List<GetAllCompaniesResponse>>(models);

            return roles.ToList();
        }
        catch (Exception ex)
        {
            throw new Exception(message: ex.Message);
        }
    }
}
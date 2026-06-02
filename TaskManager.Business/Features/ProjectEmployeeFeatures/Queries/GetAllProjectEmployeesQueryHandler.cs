using AutoMapper;
using TaskManager.Business.Abstraction.Data;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;
using TaskManager.Business.Features.DepartmentFeatures.Queries;

namespace TaskManager.Business.Features.ProjectEmployeeFeatures.Queries;

public class GetAllProjectEmployeesQueryHandler : IRequestHandler<GetAllProjectEmployeesQuery, List<GetAllProjectEmployeesResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetAllProjectEmployeesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<GetAllProjectEmployeesResponse>> Handle(GetAllProjectEmployeesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var parameters = new CustomDynamicParameters();

            var projectEmployees = await _unitOfWork.ReadDbConnection.QueryAsync<GetAllProjectEmployeesResponse>("", parameters, null, System.Data.CommandType.StoredProcedure);

            //var projectEmployees = _mapper.Map<List<GetAllCompaniesResponse>>(models);

            return projectEmployees.ToList();
        }
        catch (Exception ex)
        {
            throw new Exception(message: ex.Message);
        }
    }
}
using AutoMapper;
using TaskManager.Business.Abstraction.Data;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;
using TaskManager.Business.Features.DepartmentFeatures.Queries;

namespace TaskManager.Business.Features.EmployeeFeatures.Queries;

public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, List<GetAllEmployeesResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetAllEmployeesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<GetAllEmployeesResponse>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var parameters = new CustomDynamicParameters();

            var employees = await _unitOfWork.ReadDbConnection.QueryAsync<GetAllEmployeesResponse>("", parameters, null, System.Data.CommandType.StoredProcedure);

            //var employees = _mapper.Map<List<GetAllCompaniesResponse>>(models);

            return employees.ToList();
        }
        catch (Exception ex)
        {
            throw new Exception(message: ex.Message);
        }
    }
}
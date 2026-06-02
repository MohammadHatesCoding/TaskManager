using AutoMapper;
using TaskManager.Business.Abstraction.Data;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;
using TaskManager.Business.Features.DepartmentFeatures.Queries;

namespace TaskManager.Business.Features.AssignmentEmployeeFeatures.Queries;

public class GetAllAssignmentEmployeesQueryHandler : IRequestHandler<GetAllAssignmentEmployeesQuery, List<GetAllAssignmentEmployeesResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetAllAssignmentEmployeesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<GetAllAssignmentEmployeesResponse>> Handle(GetAllAssignmentEmployeesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var parameters = new CustomDynamicParameters();

            var assignmentEmployees = await _unitOfWork.ReadDbConnection.QueryAsync<GetAllAssignmentEmployeesResponse>("", parameters, null, System.Data.CommandType.StoredProcedure);

            //var assignmentEmployees = _mapper.Map<List<GetAllCompaniesResponse>>(models);

            return assignmentEmployees.ToList();
        }
        catch (Exception ex)
        {
            throw new Exception(message: ex.Message);
        }
    }
}
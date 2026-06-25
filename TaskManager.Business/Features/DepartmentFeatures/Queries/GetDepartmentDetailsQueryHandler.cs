using AutoMapper;
using TaskManager.Business.Abstraction.Data;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;

namespace TaskManager.Business.Features.DepartmentFeatures.Queries;

public class GetDepartmentDetailsQueryHandler : IRequestHandler<GetDepartmentDetailsQuery, GetDepartmentDetailsResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetDepartmentDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetDepartmentDetailsResponse> Handle(GetDepartmentDetailsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var departmentEntity = await _unitOfWork.DepartmentRepository.GetByIdAsync(request.query.DepartmentId);

            var department = _mapper.Map<GetDepartmentDetailsResponse>(departmentEntity);

            var parameters = new CustomDynamicParameters();

            parameters.Add("@DepartmentId", request.query.DepartmentId);

            var employees = await _unitOfWork.ReadDbConnection
                .QueryAsync<GetEmployeesByDepartmentId>("GetAllEmployeesByDepartmentId", parameters, null, System.Data.CommandType.StoredProcedure);

            department = department with { Employees = employees.ToList() };

            return department;
        }
        catch (Exception ex)
        {
            throw new Exception(message: ex.Message);
        }
    }
}
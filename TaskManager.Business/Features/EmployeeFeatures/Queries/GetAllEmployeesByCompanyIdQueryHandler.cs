using AutoMapper;
using TaskManager.Business.Abstraction.Data;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;

namespace TaskManager.Business.Features.EmployeeFeatures.Queries;

public class GetAllEmployeesByCompanyIdQueryHandler : IRequestHandler<GetAllEmployeesByCompanyIdQuery, List<GetAllEmployeesByCompanyIdResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetAllEmployeesByCompanyIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<GetAllEmployeesByCompanyIdResponse>> Handle(GetAllEmployeesByCompanyIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var parameters = new CustomDynamicParameters();

            parameters.Add("CompanyId", request.query.CompanyId);

            var models = await _unitOfWork.ReadDbConnection.QueryAsync<GetAllEmployeesByCompanyIdResponse>("GetAllEmployeesByCompanyId", parameters, null, System.Data.CommandType.StoredProcedure);

            var employees = _mapper.Map<List<GetAllEmployeesByCompanyIdResponse>>(models);

            return employees.ToList();
        }
        catch (Exception ex)
        {
            throw new Exception(message: ex.Message);
        }
    }
}
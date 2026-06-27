using AutoMapper;
using TaskManager.Business.Abstraction.Data;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;

namespace TaskManager.Business.Features.ProjectFeatures.Queries;

public class GetProjectDetailsQueryHandler : IRequestHandler<GetProjectDetailsQuery, GetProjectDetailsResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetProjectDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetProjectDetailsResponse> Handle(GetProjectDetailsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var model = await _unitOfWork.ProjectRepository.GetByIdAsync(request.query.ProjectId);

            var parameters = new CustomDynamicParameters();

            parameters.Add("ProjectId", request.query.ProjectId);

            var employees = await _unitOfWork.ReadDbConnection
                .QueryAsync<GetAllEmployeesByProjectId>("GetAllEmployeesByProjectId", parameters, null, System.Data.CommandType.StoredProcedure);

            var project = _mapper.Map<GetProjectDetailsResponse>(model);

            project = project with { ProjectEmployees = employees.ToList() };

            return project;
        }
        catch (Exception ex)
        {
            throw new Exception(message: ex.Message);
        }
    }
}
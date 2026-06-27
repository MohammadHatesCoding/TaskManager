using AutoMapper;
using TaskManager.Business.Abstraction.Data;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;
using TaskManager.Business.Features.DepartmentFeatures.Queries;

namespace TaskManager.Business.Features.ProjectFeatures.Queries;

public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, List<GetAllProjectsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetAllProjectsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<GetAllProjectsResponse>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var parameters = new CustomDynamicParameters();

            var projects = await _unitOfWork.ReadDbConnection.QueryAsync<GetAllProjectsResponse>("GetAllProjects", parameters, null, System.Data.CommandType.StoredProcedure);

            return projects.ToList();
        }
        catch (Exception ex)
        {
            throw new Exception(message: ex.Message);
        }
    }
}
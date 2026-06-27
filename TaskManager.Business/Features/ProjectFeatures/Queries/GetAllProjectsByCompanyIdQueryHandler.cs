using AutoMapper;
using TaskManager.Business.Abstraction.Data;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;

namespace TaskManager.Business.Features.ProjectFeatures.Queries;

public class GetAllProjectsByCompanyIdQueryHandler : IRequestHandler<GetAllProjectsByCompanyIdQuery, List<GetAllProjectsByCompanyIdResponse>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public GetAllProjectsByCompanyIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<List<GetAllProjectsByCompanyIdResponse>> Handle(GetAllProjectsByCompanyIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var parameters = new CustomDynamicParameters();

            parameters.Add("CompanyId", request.query.CompanyId);

            var projects = await _unitOfWork.ReadDbConnection.QueryAsync<GetAllProjectsByCompanyIdResponse>("GetAllProjectsByCompanyId", parameters, null, System.Data.CommandType.StoredProcedure);

            return projects.ToList();
        }
        catch (Exception ex)
        {
            throw new Exception(message: ex.Message);
        }
    }
}

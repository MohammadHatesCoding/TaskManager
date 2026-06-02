using AutoMapper;
using TaskManager.Business.Abstraction.Data;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;

namespace TaskManager.Business.Features.CompanyFeatures.Queries;

public class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQuery, List<GetAllCompaniesResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetAllCompaniesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<GetAllCompaniesResponse>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var parameters = new CustomDynamicParameters();

            var companies = await _unitOfWork.ReadDbConnection.QueryAsync<GetAllCompaniesResponse>("", parameters, null, System.Data.CommandType.StoredProcedure);

            //var companies = _mapper.Map<List<GetAllCompaniesResponse>>(models);

            return companies.ToList();
        }
        catch (Exception ex)
        {
            throw new Exception(message: ex.Message);
        }
    }
}
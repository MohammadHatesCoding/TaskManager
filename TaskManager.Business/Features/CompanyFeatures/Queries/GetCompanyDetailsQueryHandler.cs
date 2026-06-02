using AutoMapper;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;

namespace TaskManager.Business.Features.CompanyFeatures.Queries;

public class GetCompanyDetailsQueryHandler : IRequestHandler<GetCompanyDetailsQuery, GetCompanyDetailsResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetCompanyDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetCompanyDetailsResponse> Handle(GetCompanyDetailsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var model = await _unitOfWork.CompanyRepository.GetByIdAsync(request.query.Id);

            var company = _mapper.Map<GetCompanyDetailsResponse>(model);

            return company;
        }
        catch (Exception ex)
        {
            throw new Exception(message: ex.Message);
        }
    }
}
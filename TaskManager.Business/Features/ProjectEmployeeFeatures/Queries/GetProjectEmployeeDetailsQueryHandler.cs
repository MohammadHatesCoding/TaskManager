using AutoMapper;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;

namespace TaskManager.Business.Features.ProjectEmployeeFeatures.Queries;

public class GetProjectEmployeeDetailsQueryHandler : IRequestHandler<GetProjectEmployeeDetailsQuery, GetProjectEmployeeDetailsResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetProjectEmployeeDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetProjectEmployeeDetailsResponse> Handle(GetProjectEmployeeDetailsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var model = await _unitOfWork.ProjectEmployeeRepository.GetByIdAsync(request.query.Id);

            var projectEmployee = _mapper.Map<GetProjectEmployeeDetailsResponse>(model);

            return projectEmployee;
        }
        catch (Exception ex)
        {
            throw new Exception(message: ex.Message);
        }
    }
}
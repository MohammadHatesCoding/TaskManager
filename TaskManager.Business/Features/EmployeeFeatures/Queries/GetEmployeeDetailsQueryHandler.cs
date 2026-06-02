using AutoMapper;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;

namespace TaskManager.Business.Features.EmployeeFeatures.Queries;

public class GetEmployeeDetailsQueryHandler : IRequestHandler<GetEmployeeDetailsQuery, GetEmployeeDetailsResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetEmployeeDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetEmployeeDetailsResponse> Handle(GetEmployeeDetailsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var model = await _unitOfWork.EmployeeRepository.GetByIdAsync(request.query.Id);

            var employee = _mapper.Map<GetEmployeeDetailsResponse>(model);

            return employee;
        }
        catch (Exception ex)
        {
            throw new Exception(message: ex.Message);
        }
    }
}
using AutoMapper;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;

namespace TaskManager.Business.Features.AssignmentEmployeeFeatures.Queries;

public class GetAssignmentEmployeeDetailsQueryHandler : IRequestHandler<GetAssignmentEmployeeDetailsQuery, GetAssignmentEmployeeDetailsResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetAssignmentEmployeeDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetAssignmentEmployeeDetailsResponse> Handle(GetAssignmentEmployeeDetailsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var model = await _unitOfWork.AssignmentEmployeeRepository.GetByIdAsync(request.query.Id);

            var assignmentEmployee = _mapper.Map<GetAssignmentEmployeeDetailsResponse>(model);

            return assignmentEmployee;
        }
        catch (Exception ex)
        {
            throw new Exception(message: ex.Message);
        }
    }
}
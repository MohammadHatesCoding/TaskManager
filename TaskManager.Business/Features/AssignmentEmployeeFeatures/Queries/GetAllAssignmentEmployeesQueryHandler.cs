using AutoMapper;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;

namespace TaskManager.Business.Features.AssignmentEmployeeFeatures.Queries;

public class GetAllAssignmentEmployeesQueryHandler : IRequestHandler<GetAllAssignmentEmployeesQuery, List<GetAllAssignmentEmployeesResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetAllAssignmentEmployeesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<GetAllAssignmentEmployeesResponse>> Handle(GetAllAssignmentEmployeesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var models = await _unitOfWork.AssignmentEmployeeRepository.GetAllAsync();

            var assignmentEmployees = _mapper.Map<List<GetAllAssignmentEmployeesResponse>>(models);

            return assignmentEmployees.ToList();
        }
        catch (Exception ex)
        {
            throw new Exception(message: ex.Message);
        }
    }
}
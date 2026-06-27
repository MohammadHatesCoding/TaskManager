using AutoMapper;
using TaskManager.Business.Abstraction.Data;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;

namespace TaskManager.Business.Features.AssignmentFeatures.Queries;

public class GetAllAssignmentsQueryHandler : IRequestHandler<GetAllAssignmentsQuery, List<GetAllAssignmentsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetAllAssignmentsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<GetAllAssignmentsResponse>> Handle(GetAllAssignmentsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var parameters = new CustomDynamicParameters();

            var assignments = await _unitOfWork.ReadDbConnection
                .QueryAsync<GetAllAssignmentsResponse>("GetAllAssignments", parameters, null, System.Data.CommandType.StoredProcedure);

            return assignments.ToList();
        }
        catch (Exception ex)
        {
            throw new Exception(message: ex.Message);
        }
    }
}
using AutoMapper;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;

namespace TaskManager.Business.Features.AssignmentFeatures.Queries;

public class GetAssignmentDetailsQueryHandler : IRequestHandler<GetAssignmentDetailsQuery, GetAssignmentDetailsResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetAssignmentDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetAssignmentDetailsResponse> Handle(GetAssignmentDetailsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var model = await _unitOfWork.AssignmentRepository.GetByIdAsync(request.query.Id);

            var assignment = _mapper.Map<GetAssignmentDetailsResponse>(model);

            return assignment;
        }
        catch (Exception ex)
        {
            throw new Exception(message: ex.Message);
        }
    }
}
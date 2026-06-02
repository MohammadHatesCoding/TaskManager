using AutoMapper;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;

namespace TaskManager.Business.Features.ProjectFeatures.Queries;

public class GetProjectDetailsQueryHandler : IRequestHandler<GetProjectDetailsQuery, GetProjectDetailsResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetProjectDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetProjectDetailsResponse> Handle(GetProjectDetailsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var model = await _unitOfWork.ProjectRepository.GetByIdAsync(request.query.Id);

            var project = _mapper.Map<GetProjectDetailsResponse>(model);

            return project;
        }
        catch (Exception ex)
        {
            throw new Exception(message: ex.Message);
        }
    }
}
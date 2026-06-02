using AutoMapper;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;
using TaskManager.Domain.Models;

namespace TaskManager.Business.Features.ProjectFeatures.Commands;

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, CreateProjectResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public CreateProjectCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateProjectResponse> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var project = _mapper.Map<Project>(request.command);

            await _unitOfWork.ProjectRepository.CreateAsync(project);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new CreateProjectResponse(Id: project.Id);
        }
        catch (Exception ex) 
        {
            throw new Exception(message: ex.Message);
        }
    }
}
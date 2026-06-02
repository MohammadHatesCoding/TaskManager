using AutoMapper;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;
using TaskManager.Domain.Models;

namespace TaskManager.Business.Features.ProjectFeatures.Commands;

public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, UpdateProjectResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateProjectCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<UpdateProjectResponse> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var project = await _unitOfWork.ProjectRepository.GetByIdAsync(request.command.Id);

            project = _mapper.Map<Project>(request.command);

            await _unitOfWork.ProjectRepository.UpdateAsync(project);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new UpdateProjectResponse(Id: project.Id);
        }
        catch (Exception ex) 
        {
            throw new Exception(message: ex.Message);
        }
    }
}

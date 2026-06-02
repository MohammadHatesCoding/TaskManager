using AutoMapper;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;
using TaskManager.Domain.Models;

namespace TaskManager.Business.Features.ProjectFeatures.Commands;

public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, DeleteProjectResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteProjectCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<DeleteProjectResponse> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var project = await _unitOfWork.ProjectRepository.GetByIdAsync(request.command.Id);

            project.IsDeleted = true;

            await _unitOfWork.CommitAsync(cancellationToken);

            return new DeleteProjectResponse(Id: project.Id);
        }
        catch (Exception ex) 
        {
            throw new Exception(message: ex.Message);
        }
    }
}
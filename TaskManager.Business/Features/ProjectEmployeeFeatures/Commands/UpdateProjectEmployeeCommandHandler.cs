using AutoMapper;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;
using TaskManager.Domain.Models;

namespace TaskManager.Business.Features.ProjectEmployeeFeatures.Commands;

public class UpdateProjectEmployeeCommandHandler : IRequestHandler<UpdateProjectEmployeeCommand, UpdateProjectEmployeeResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateProjectEmployeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<UpdateProjectEmployeeResponse> Handle(UpdateProjectEmployeeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var projectEmployee = await _unitOfWork.ProjectEmployeeRepository.GetByIdAsync(request.command.Id);

            projectEmployee = _mapper.Map<ProjectEmployee>(request.command);

            await _unitOfWork.ProjectEmployeeRepository.UpdateAsync(projectEmployee);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new UpdateProjectEmployeeResponse(Id: projectEmployee.Id);
        }
        catch (Exception ex) 
        {
            throw new Exception(message: ex.Message);
        }
    }
}

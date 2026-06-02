using AutoMapper;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;
using TaskManager.Domain.Models;

namespace TaskManager.Business.Features.AssignmentEmployeeFeatures.Commands;

public class UpdateAssignmentEmployeeCommandHandler : IRequestHandler<UpdateAssignmentEmployeeCommand, UpdateAssignmentEmployeeResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateAssignmentEmployeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<UpdateAssignmentEmployeeResponse> Handle(UpdateAssignmentEmployeeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var assignmentEmployee = await _unitOfWork.AssignmentEmployeeRepository.GetByIdAsync(request.command.Id);

            assignmentEmployee = _mapper.Map<AssignmentEmployee>(request.command);

            await _unitOfWork.AssignmentEmployeeRepository.UpdateAsync(assignmentEmployee);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new UpdateAssignmentEmployeeResponse(Id: assignmentEmployee.Id);
        }
        catch (Exception ex) 
        {
            throw new Exception(message: ex.Message);
        }
    }
}

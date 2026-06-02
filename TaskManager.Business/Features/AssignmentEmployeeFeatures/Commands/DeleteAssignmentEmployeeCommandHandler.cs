using AutoMapper;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;
using TaskManager.Domain.Models;

namespace TaskManager.Business.Features.AssignmentEmployeeFeatures.Commands;

public class DeleteAssignmentEmployeeCommandHandler : IRequestHandler<DeleteAssignmentEmployeeCommand, DeleteAssignmentEmployeeResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteAssignmentEmployeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<DeleteAssignmentEmployeeResponse> Handle(DeleteAssignmentEmployeeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var assignmentEmployee = await _unitOfWork.AssignmentEmployeeRepository.GetByIdAsync(request.command.Id);

            assignmentEmployee.IsDeleted = true;

            await _unitOfWork.CommitAsync(cancellationToken);

            return new DeleteAssignmentEmployeeResponse(Id: assignmentEmployee.Id);
        }
        catch (Exception ex) 
        {
            throw new Exception(message: ex.Message);
        }
    }
}
using AutoMapper;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;
using TaskManager.Domain.Models;

namespace TaskManager.Business.Features.AssignmentEmployeeFeatures.Commands;

public class CreateAssignmentEmployeeCommandHandler : IRequestHandler<CreateAssignmentEmployeeCommand, CreateAssignmentEmployeeResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public CreateAssignmentEmployeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateAssignmentEmployeeResponse> Handle(CreateAssignmentEmployeeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var assignmentEmployee = _mapper.Map<AssignmentEmployee>(request.command);

            await _unitOfWork.AssignmentEmployeeRepository.CreateAsync(assignmentEmployee);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new CreateAssignmentEmployeeResponse(Id: assignmentEmployee.Id);
        }
        catch (Exception ex) 
        {
            throw new Exception(message: ex.Message);
        }
    }
}
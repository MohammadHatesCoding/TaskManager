using AutoMapper;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;
using TaskManager.Domain.Models;

namespace TaskManager.Business.Features.AssignmentFeatures.Commands;

public class UpdateAssignmentCommandHandler : IRequestHandler<UpdateAssignmentCommand, UpdateAssignmentResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateAssignmentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<UpdateAssignmentResponse> Handle(UpdateAssignmentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var assignment = await _unitOfWork.AssignmentRepository.GetByIdAsync(request.command.Id);

            assignment = _mapper.Map<Assignment>(request.command);

            await _unitOfWork.AssignmentRepository.UpdateAsync(assignment);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new UpdateAssignmentResponse(Id: assignment.Id);
        }
        catch (Exception ex) 
        {
            throw new Exception(message: ex.Message);
        }
    }
}

using AutoMapper;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;
using TaskManager.Domain.Models;

namespace TaskManager.Business.Features.ProjectEmployeeFeatures.Commands;

public class DeleteProjectEmployeeCommandHandler : IRequestHandler<DeleteProjectEmployeeCommand, DeleteProjectEmployeeResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteProjectEmployeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<DeleteProjectEmployeeResponse> Handle(DeleteProjectEmployeeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var projectEmployee = await _unitOfWork.ProjectEmployeeRepository.GetByIdAsync(request.command.ProjectEmployeeId);

            projectEmployee.IsDeleted = true;

            await _unitOfWork.CommitAsync(cancellationToken);

            return new DeleteProjectEmployeeResponse(Success: true);
        }
        catch (Exception ex) 
        {
            throw new Exception(message: ex.Message);
        }
    }
}
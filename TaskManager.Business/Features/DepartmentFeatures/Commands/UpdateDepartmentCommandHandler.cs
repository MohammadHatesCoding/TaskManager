using AutoMapper;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;
using TaskManager.Domain.Models;

namespace TaskManager.Business.Features.DepartmentFeatures.Commands;

public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, UpdateDepartmentResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateDepartmentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<UpdateDepartmentResponse> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var department = await _unitOfWork.DepartmentRepository.GetByIdAsync(request.command.Id);

            department = _mapper.Map<Department>(request.command);

            await _unitOfWork.DepartmentRepository.UpdateAsync(department);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new UpdateDepartmentResponse(Id: department.Id);
        }
        catch (Exception ex) 
        {
            throw new Exception(message: ex.Message);
        }
    }
}

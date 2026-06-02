using AutoMapper;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;
using TaskManager.Domain.Models;

namespace TaskManager.Business.Features.EmployeeFeatures.Commands;

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, UpdateEmployeeResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateEmployeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<UpdateEmployeeResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(request.command.Id);

            employee = _mapper.Map<Employee>(request.command);

            await _unitOfWork.EmployeeRepository.UpdateAsync(employee);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new UpdateEmployeeResponse(Id: employee.Id);
        }
        catch (Exception ex) 
        {
            throw new Exception(message: ex.Message);
        }
    }
}

using AutoMapper;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;
using TaskManager.Domain.Models;

namespace TaskManager.Business.Features.EmployeeFeatures.Commands;

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, CreateEmployeeResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public CreateEmployeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateEmployeeResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var employee = _mapper.Map<Employee>(request.command);

            await _unitOfWork.EmployeeRepository.CreateAsync(employee);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new CreateEmployeeResponse(Id: employee.Id);
        }
        catch (Exception ex) 
        {
            throw new Exception(message: ex.Message);
        }
    }
}
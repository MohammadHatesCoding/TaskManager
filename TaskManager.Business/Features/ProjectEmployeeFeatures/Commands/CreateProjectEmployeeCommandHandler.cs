using AutoMapper;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;
using TaskManager.Domain.Models;

namespace TaskManager.Business.Features.ProjectEmployeeFeatures.Commands;

public class CreateProjectEmployeeCommandHandler : IRequestHandler<CreateProjectEmployeeCommand, CreateProjectEmployeeResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public CreateProjectEmployeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateProjectEmployeeResponse> Handle(CreateProjectEmployeeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(request.command.EmployeeId);

            var project = await _unitOfWork.ProjectRepository.GetByIdAsync(request.command.ProjectId);

            if ((employee is null && project is null) && employee.CompanyId != project.CompanyId)
                throw new Exception(message: "Employee is not in this company");

            var projectEmployee = _mapper.Map<ProjectEmployee>(request.command);

            await _unitOfWork.ProjectEmployeeRepository.CreateAsync(projectEmployee);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new CreateProjectEmployeeResponse(Id: projectEmployee.Id);
        }
        catch (Exception ex) 
        {
            throw new Exception(message: ex.Message);
        }
    }
}
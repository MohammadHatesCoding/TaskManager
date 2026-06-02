using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Controllers.Base;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Features.EmployeeFeatures.Commands;
using TaskManager.Business.Features.EmployeeFeatures.Queries;

namespace TaskManager.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : BaseController
{
    private readonly IDispatcher _dispatcher;
    public EmployeeController(IDispatcher dispatcher) : base(dispatcher)
    {
        _dispatcher = dispatcher;
    }

    [HttpPost]
    [Route(nameof(Create))]
    public async Task<CreateEmployeeResponse> Create(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<CreateEmployeeResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(Update))]
    public async Task<UpdateEmployeeResponse> Update(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<UpdateEmployeeResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(Delete))]
    public async Task<DeleteEmployeeResponse> Delete(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<DeleteEmployeeResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpGet]
    [Route(nameof(GetAll))]
    public async Task<List<GetAllEmployeesResponse>> GetAll(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<List<GetAllEmployeesResponse>>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }
    [HttpPost]
    [Route(nameof(GetDetails))]
    public async Task<GetEmployeeDetailsResponse> GetDetails(GetEmployeeDetailsQuery request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<GetEmployeeDetailsResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }
}
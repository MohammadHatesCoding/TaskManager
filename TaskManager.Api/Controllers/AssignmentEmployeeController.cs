using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Controllers.Base;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Features.AssignmentEmployeeFeatures.Commands;
using TaskManager.Business.Features.AssignmentEmployeeFeatures.Queries;

namespace TaskManager.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AssignmentEmployeeController : BaseController
{
    private readonly IDispatcher _dispatcher;
    public AssignmentEmployeeController(IDispatcher dispatcher) : base(dispatcher)
    {
        _dispatcher = dispatcher;
    }

    [HttpPost]
    [Route(nameof(Create))]
    public async Task<CreateAssignmentEmployeeResponse> Create(CreateAssignmentEmployeeCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<CreateAssignmentEmployeeResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(Update))]
    public async Task<UpdateAssignmentEmployeeResponse> Update(UpdateAssignmentEmployeeCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<UpdateAssignmentEmployeeResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(Delete))]
    public async Task<DeleteAssignmentEmployeeResponse> Delete(DeleteAssignmentEmployeeCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<DeleteAssignmentEmployeeResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpGet]
    [Route(nameof(GetAll))]
    public async Task<List<GetAllAssignmentEmployeesResponse>> GetAll(GetAllAssignmentEmployeesQuery request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<List<GetAllAssignmentEmployeesResponse>>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }
    [HttpPost]
    [Route(nameof(GetDetails))]
    public async Task<GetAssignmentEmployeeDetailsResponse> GetDetails(GetAssignmentEmployeeDetailsQuery request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<GetAssignmentEmployeeDetailsResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }
}
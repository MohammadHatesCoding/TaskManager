using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Controllers.Base;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Features.ProjectEmployeeFeatures.Commands;
using TaskManager.Business.Features.ProjectEmployeeFeatures.Queries;

namespace TaskManager.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectEmployeeController : BaseController
{
    private readonly IDispatcher _dispatcher;
    public ProjectEmployeeController(IDispatcher dispatcher) : base(dispatcher)
    {
        _dispatcher = dispatcher;
    }

    [HttpPost]
    [Route(nameof(Create))]
    [Authorize("SysAdmin")]
    public async Task<CreateProjectEmployeeResponse> Create(CreateProjectEmployeeCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<CreateProjectEmployeeResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(Update))]
    [Authorize("SysAdmin")]
    public async Task<UpdateProjectEmployeeResponse> Update(UpdateProjectEmployeeCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<UpdateProjectEmployeeResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(Delete))]
    [Authorize("SysAdmin")]
    public async Task<DeleteProjectEmployeeResponse> Delete(DeleteProjectEmployeeCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<DeleteProjectEmployeeResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpGet]
    [Route(nameof(GetAll))]
    [Authorize("SysAdmin")]
    public async Task<List<GetAllProjectEmployeesResponse>> GetAll(GetAllProjectEmployeesQuery request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<List<GetAllProjectEmployeesResponse>>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }
    [HttpPost]
    [Route(nameof(GetDetails))]
    [Authorize("SysAdmin")]
    public async Task<GetProjectEmployeeDetailsResponse> GetDetails(GetProjectEmployeeDetailsQuery request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<GetProjectEmployeeDetailsResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }
}
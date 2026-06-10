using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Controllers.Base;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Features.DepartmentFeatures.Commands;
using TaskManager.Business.Features.DepartmentFeatures.Queries;

namespace TaskManager.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentController : BaseController
{
    private readonly IDispatcher _dispatcher;
    public DepartmentController(IDispatcher dispatcher) : base(dispatcher)
    {
        _dispatcher = dispatcher;
    }

    [HttpPost]
    [Route(nameof(Create))]
    [Authorize("SysAdmin")]
    public async Task<CreateDepartmentResponse> Create(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<CreateDepartmentResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(Update))]
    [Authorize("SysAdmin")]
    public async Task<UpdateDepartmentResponse> Update(UpdateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<UpdateDepartmentResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(Delete))]
    [Authorize("SysAdmin")]
    public async Task<DeleteDepartmentResponse> Delete(DeleteDepartmentCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<DeleteDepartmentResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpGet]
    [Route(nameof(GetAll))]
    [Authorize("SysAdmin")]
    public async Task<List<GetAllDepartmentsResponse>> GetAll(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<List<GetAllDepartmentsResponse>>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }
    [HttpPost]
    [Route(nameof(GetDetails))]
    [Authorize("SysAdmin")]
    public async Task<GetDepartmentDetailsResponse> GetDetails(GetDepartmentDetailsQuery request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<GetDepartmentDetailsResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }
}

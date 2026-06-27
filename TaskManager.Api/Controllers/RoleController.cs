using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Controllers.Base;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Features.ProjectFeatures.Commands;
using TaskManager.Business.Features.ProjectFeatures.Queries;
using TaskManager.Business.Features.RoleFeatures.Commands;
using TaskManager.Business.Features.RoleFeatures.Queries;

namespace TaskManager.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController : BaseController
{
    private readonly IDispatcher _dispatcher;
    public RoleController(IDispatcher dispatcher) : base(dispatcher)
    {
        _dispatcher = dispatcher;
    }

    [HttpPost]
    [Route(nameof(Create))]
    [Authorize("SysAdmin")]
    public async Task<CreateRoleResponse> Create(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<CreateRoleResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(Update))]
    [Authorize("SysAdmin")]
    public async Task<UpdateRoleResponse> Update(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<UpdateRoleResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(Delete))]
    [Authorize("SysAdmin")]
    public async Task<DeleteRoleResponse> Delete(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<DeleteRoleResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpGet]
    [Route(nameof(GetAll))]
    [Authorize("SysAdmin")]
    public async Task<List<GetAllRolesResponse>> GetAll(CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<List<GetAllRolesResponse>>(new GetAllRolesQuery(new GetAllRolesRequest()), cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(GetDetails))]
    [Authorize("SysAdmin")]
    public async Task<GetRoleDetailsResponse> GetDetails(GetRoleDetailsQuery request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<GetRoleDetailsResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }
}
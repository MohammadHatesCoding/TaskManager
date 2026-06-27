using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Controllers.Base;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Features.UserRoleFeatures.Commands;
using TaskManager.Business.Features.UserRoleFeatures.Queries;

namespace TaskManager.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserRoleController : BaseController
{
    private readonly IDispatcher _dispatcher;
    public UserRoleController(IDispatcher dispatcher) : base(dispatcher)
    {
        _dispatcher = dispatcher;
    }

    [HttpPost]
    [Route(nameof(Create))]
    [Authorize("SysAdmin")]
    public async Task<CreateUserRoleResponse> Create(CreateUserRoleCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<CreateUserRoleResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(Delete))]
    [Authorize("SysAdmin")]
    public async Task<DeleteUserRoleResponse> Delete(DeleteUserRoleCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<DeleteUserRoleResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(GetAllByRoleId))]
    [Authorize("SysAdmin")]
    public async Task<List<GetUserRolesByRoleIdResponse>> GetAllByRoleId(GetUserRolesByRoleIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<List<GetUserRolesByRoleIdResponse>>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(GetAllByUserId))]
    [Authorize("SysAdmin")]
    public async Task<List<GetUserRolesByUserIdResponse>> GetAllByUserId(GetUserRolesByUserIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<List<GetUserRolesByUserIdResponse>>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }
}
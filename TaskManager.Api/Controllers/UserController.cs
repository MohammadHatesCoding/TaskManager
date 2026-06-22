using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Controllers.Base;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Features.UserFeatures.Commands;
using TaskManager.Business.Features.UserFeatures.Queries;

namespace TaskManager.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : BaseController
{
    private readonly IDispatcher _dispatcher;
    public UserController(IDispatcher dispatcher) : base(dispatcher)
    {
        _dispatcher = dispatcher;
    }

    [HttpPost]
    [Route(nameof(Create))]
    [Authorize("SysAdmin")]
    public async Task<CreateUserResponse> Create(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<CreateUserResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(Update))]
    [Authorize("SysAdmin")]
    public async Task<UpdateUserResponse> Update(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<UpdateUserResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(UpdateProfile))]
    [Authorize("SysAdmin")]
    public async Task<UpdateMyProfileResponse> UpdateProfile(UpdateMyProfileCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<UpdateMyProfileResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(Delete))]
    [Authorize("SysAdmin")]
    public async Task<DeleteUserResponse> Delete(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<DeleteUserResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(ToggleActivity))]
    [Authorize("SysAdmin")]
    public async Task<ToggleUserActivityResponse> ToggleActivity(ToggleUserActivityCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<ToggleUserActivityResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(ToggleBlock))]
    [Authorize("SysAdmin")]
    public async Task<UserBlockToggleResponse> ToggleBlock(UserBlockToggleCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<UserBlockToggleResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(HasPassword))]
    [Authorize("SysAdmin")]
    public async Task<HasPasswordResponse> HasPassword(HasPasswordCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<HasPasswordResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpGet]
    [Route(nameof(GetAll))]
    [Authorize("SysAdmin")]
    public async Task<List<GetAllUsersResponse>> GetAll(CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<List<GetAllUsersResponse>>(new GetAllUsersQuery(new GetAllUsersRequest()), cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(GetDetails))]
    [Authorize("SysAdmin")]
    public async Task<GetUserDetailsResponse> GetDetails(GetUserDetailsQuery request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<GetUserDetailsResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpGet]
    [Route(nameof(GetProfileDetails))]
    [Authorize("SysAdmin")]
    public async Task<GetProfileDetailsResponse> GetProfileDetails(CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<GetProfileDetailsResponse>(new GetProfileDetailsQuery(new GetProfileDetailsRequest()), cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }
}
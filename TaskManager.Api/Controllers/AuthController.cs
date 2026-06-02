using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Controllers.Base;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Features.AuthFeatures.Commands;

namespace TaskManager.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : BaseController
{
    private readonly IDispatcher _dispatcher;
    public AuthController(IDispatcher dispatcher) : base(dispatcher)
    {
        _dispatcher = dispatcher;
    }

    [HttpPost]
    [Route(nameof(Register))]
    public async Task<RegisterResponse> Register(RegisterCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<RegisterResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(Login))]
    public async Task<LoginResponse> Login(LoginCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<LoginResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(Logout))]
    public async Task<LogoutResponse> Logout(LogoutCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<LogoutResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(Refresh))]
    public async Task<RefreshResponse> Refresh(RefreshCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<RefreshResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(CreatePassword))]
    public async Task<CreatePasswordResponse> CreatePassword(CreatePasswordCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<CreatePasswordResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(ChangePassword))]
    public async Task<ChangePasswordResponse> ChangePassword(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<ChangePasswordResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(ForgotPassword))]
    public async Task<ForgotPasswordResponse> ForgotPassword(ForgotPasswordCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<ForgotPasswordResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(ResetPassword))]
    public async Task<ResetPasswordResponse> ResetPassword(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<ResetPasswordResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(CheckOtp))]
    public async Task<CheckOTPResponse> CheckOtp(CheckOTPCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<CheckOTPResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }
}
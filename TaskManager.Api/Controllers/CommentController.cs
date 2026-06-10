using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Controllers.Base;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Features.CommentFeatures.Commands;
using TaskManager.Business.Features.CommentFeatures.Queries;
using TaskManager.Business.Features.ProjectFeatures.Commands;
using TaskManager.Business.Features.ProjectFeatures.Queries;

namespace TaskManager.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentController : BaseController
{
    private readonly IDispatcher _dispatcher;
    public CommentController(IDispatcher dispatcher) : base(dispatcher)
    {
        _dispatcher = dispatcher;
    }

    [HttpPost]
    [Route(nameof(Create))]
    [Authorize(Roles = "SysAdmin")]
    public async Task<CreateCommentResponse> Create(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<CreateCommentResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(Update))]
    [Authorize(Roles = "SysAdmin")]
    public async Task<UpdateCommentResponse> Update(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<UpdateCommentResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(Delete))]
    [Authorize(Roles = "SysAdmin")]
    public async Task<DeleteCommentResponse> Delete(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<DeleteCommentResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpGet]
    [Route(nameof(GetAll))]
    [Authorize(Roles = "SysAdmin")]
    public async Task<List<GetAllCommentsResponse>> GetAll(GetAllCommentsQuery request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<List<GetAllCommentsResponse>>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }
    [HttpPost]
    [Route(nameof(GetDetails))]
    [Authorize(Roles = "SysAdmin")]
    public async Task<GetCommentDetailsResponse> GetDetails(GetCommentDetailsQuery request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<GetCommentDetailsResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }
}
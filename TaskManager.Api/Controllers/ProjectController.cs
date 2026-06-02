using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Controllers.Base;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Features.ProjectFeatures.Commands;
using TaskManager.Business.Features.ProjectFeatures.Queries;

namespace TaskManager.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize("SysAdmin")]
public class ProjectController : BaseController
{
    private readonly IDispatcher _dispatcher;
    public ProjectController(IDispatcher dispatcher) : base(dispatcher)
    {
        _dispatcher = dispatcher;
    }

    [HttpPost]
    [Route(nameof(Create))]
    public async Task<CreateProjectResponse> Create(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<CreateProjectResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(Update))]
    public async Task<UpdateProjectResponse> Update(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<UpdateProjectResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(Delete))]
    public async Task<DeleteProjectResponse> Delete(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<DeleteProjectResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpGet]
    [Route(nameof(GetAll))]
    public async Task<List<GetAllProjectsResponse>> GetAll(GetAllProjectsQuery request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<List<GetAllProjectsResponse>>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }
    [HttpPost]
    [Route(nameof(GetDetails))]
    public async Task<GetProjectDetailsResponse> GetDetails(GetProjectDetailsQuery request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<GetProjectDetailsResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }
}
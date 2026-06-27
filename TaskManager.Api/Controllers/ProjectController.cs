using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Controllers.Base;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Features.ProjectFeatures.Commands;
using TaskManager.Business.Features.ProjectFeatures.Queries;

namespace TaskManager.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectController : BaseController
{
    private readonly IDispatcher _dispatcher;
    public ProjectController(IDispatcher dispatcher) : base(dispatcher)
    {
        _dispatcher = dispatcher;
    }

    [HttpPost]
    [Route(nameof(Create))]
    [Authorize("SysAdmin")]
    public async Task<CreateProjectResponse> Create(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<CreateProjectResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(Update))]
    [Authorize("SysAdmin")]
    public async Task<UpdateProjectResponse> Update(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<UpdateProjectResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(Delete))]
    [Authorize("SysAdmin")]
    public async Task<DeleteProjectResponse> Delete(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<DeleteProjectResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpGet]
    [Route(nameof(GetAll))]
    [Authorize("SysAdmin")]
    public async Task<List<GetAllProjectsResponse>> GetAll(CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<List<GetAllProjectsResponse>>(new GetAllProjectsQuery(new GetAllProjectsRequest()), cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(GetAllProjectsByCompanyId))]
    [Authorize("SysAdmin")]
    public async Task<List<GetAllProjectsByCompanyIdResponse>> GetAllProjectsByCompanyId(GetAllProjectsByCompanyIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<List<GetAllProjectsByCompanyIdResponse>>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(GetDetails))]
    [Authorize("SysAdmin")]
    public async Task<GetProjectDetailsResponse> GetDetails(GetProjectDetailsQuery request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<GetProjectDetailsResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }
}
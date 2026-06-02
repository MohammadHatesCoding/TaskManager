using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Controllers.Base;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Features.AssignmentFeatures.Commands;
using TaskManager.Business.Features.AssignmentFeatures.Queries;

namespace TaskManager.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AssignmentController : BaseController
{
    private readonly IDispatcher _dispatcher;
    public AssignmentController(IDispatcher dispatcher) : base(dispatcher)
    {
        _dispatcher = dispatcher;
    }

    [HttpPost]
    [Route(nameof(Create))]
    [Authorize(Roles = "SysAdmin")]
    public async Task<CreateAssignmentResponse> Create(CreateAssignmentCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<CreateAssignmentResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(Update))]
    [Authorize(Roles = "Admin")]
    public async Task<UpdateAssignmentResponse> Update(UpdateAssignmentCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<UpdateAssignmentResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(Delete))]
    [Authorize(Roles = "Admin")]
    public async Task<DeleteAssignmentResponse> Delete(DeleteAssignmentCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<DeleteAssignmentResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpGet]
    [Route(nameof(GetAll))]
    [Authorize(Roles = "Admin")]
    public async Task<List<GetAllAssignmentsResponse>> GetAll(GetAllAssignmentsQuery request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<List<GetAllAssignmentsResponse>>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }
    [HttpPost]
    [Route(nameof(GetDetails))]
    [Authorize(Roles = "Admin")]
    public async Task<GetAssignmentDetailsResponse> GetDetails(GetAssignmentDetailsQuery request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<GetAssignmentDetailsResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Controllers.Base;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Features.CompanyFeatures.Commands;
using TaskManager.Business.Features.CompanyFeatures.Queries;

namespace TaskManager.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyController : BaseController
{
    private readonly IDispatcher _dispatcher;
    public CompanyController(IDispatcher dispatcher) : base(dispatcher)
    {
        _dispatcher = dispatcher;
    }

    [HttpPost]
    [Route(nameof(Create))]
    [Authorize("SysAdmin")]
    public async Task<CreateCompanyResponse> Create(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<CreateCompanyResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(Update))]
    [Authorize("SysAdmin")]
    public async Task<UpdateCompanyResponse> Update(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<UpdateCompanyResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(Delete))]
    [Authorize("SysAdmin")]
    public async Task<DeleteCompanyResponse> Delete(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<DeleteCompanyResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpGet]
    [Route(nameof(GetAll))]
    [Authorize("SysAdmin")]
    public async Task<List<GetAllCompaniesResponse>> GetAll(CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<List<GetAllCompaniesResponse>>(new GetAllCompaniesQuery(new GetAllCompaniesRequest()), cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(GetDetails))]
    [Authorize("SysAdmin")]
    public async Task<GetCompanyDetailsResponse> GetDetails(GetCompanyDetailsQuery request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<GetCompanyDetailsResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }
}
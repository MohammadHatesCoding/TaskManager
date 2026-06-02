using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Controllers.Base;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Features.CompanyFeatures.Commands;
using TaskManager.Business.Features.CompanyFeatures.Queries;

namespace TaskManager.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize("SysAdmin")]
public class CompanyController : BaseController
{
    private readonly IDispatcher _dispatcher;
    public CompanyController(IDispatcher dispatcher) : base(dispatcher)
    {
        _dispatcher = dispatcher;
    }

    [HttpPost]
    [Route(nameof(Create))]
    public async Task<CreateCompanyResponse> Create([FormFile] CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<CreateCompanyResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(Update))]
    public async Task<UpdateCompanyResponse> Update(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<UpdateCompanyResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpPost]
    [Route(nameof(Delete))]
    public async Task<DeleteCompanyResponse> Delete(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<DeleteCompanyResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }

    [HttpGet]
    [Route(nameof(GetAll))]
    public async Task<List<GetAllCompaniesResponse>> GetAll(GetAllCompaniesQuery request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<List<GetAllCompaniesResponse>>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }
    [HttpPost]
    [Route(nameof(GetDetails))]
    public async Task<GetCompanyDetailsResponse> GetDetails(GetCompanyDetailsQuery request, CancellationToken cancellationToken)
    {
        var result = await _dispatcher.Send<GetCompanyDetailsResponse>(request, cancellationToken);

        if (result is null)
            throw new Exception();

        return result;
    }
}
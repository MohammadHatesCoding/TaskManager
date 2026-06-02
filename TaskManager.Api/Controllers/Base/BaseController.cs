using Microsoft.AspNetCore.Mvc;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Api.Controllers.Base;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    private readonly IDispatcher _dispatcher;
    public BaseController(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }
}
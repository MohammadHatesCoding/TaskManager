using Microsoft.AspNetCore.Http;
using TaskManager.Business.Abstraction.Interfaces.Services;

namespace TaskManager.Infrastructure.Services;

public class CurrentCompanyService : ICurrentCompanyService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public CurrentCompanyService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public int CompanyId
    {
        get
        {
            var value = _httpContextAccessor.HttpContext?
                .Request
                .Headers["companyId"]
                .FirstOrDefault();

            if (string.IsNullOrWhiteSpace(value))
                throw new UnauthorizedAccessException("Company is required.");

            if (!int.TryParse(value, out var companyId))
                throw new UnauthorizedAccessException("Invalid CompanyId.");

            return companyId;
        }
    }
}

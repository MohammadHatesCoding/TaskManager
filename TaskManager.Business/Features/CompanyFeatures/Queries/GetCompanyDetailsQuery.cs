using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.CompanyFeatures.Queries;

public record GetCompanyDetailsQuery(GetCompanyDetailsRequest query) : IRequest<GetCompanyDetailsResponse>;
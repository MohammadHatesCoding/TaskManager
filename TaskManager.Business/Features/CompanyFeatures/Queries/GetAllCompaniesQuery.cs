using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.CompanyFeatures.Queries;

public record GetAllCompaniesQuery(GetAllCompaniesRequest query) : IRequest<List<GetAllCompaniesResponse>>;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.CompanyFeatures.Commands;

public record CreateCompanyCommand(CreateCompanyRequest command) : IRequest<CreateCompanyResponse>;
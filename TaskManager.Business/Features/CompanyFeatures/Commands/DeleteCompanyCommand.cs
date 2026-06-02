using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.CompanyFeatures.Commands;

public record DeleteCompanyCommand(DeleteCompanyRequest command) : IRequest<DeleteCompanyResponse>;
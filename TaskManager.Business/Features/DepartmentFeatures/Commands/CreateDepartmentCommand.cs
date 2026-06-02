using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.DepartmentFeatures.Commands;

public record CreateDepartmentCommand(CreateDepartmentRequest command) : IRequest<CreateDepartmentResponse>;
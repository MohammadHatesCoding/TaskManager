using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.DepartmentFeatures.Commands;

public record DeleteDepartmentCommand(DeleteDepartmentRequest command) : IRequest<DeleteDepartmentResponse>;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.AuthFeatures.Commands;

public record CheckOTPCommand(CheckOTPRequest command) : IRequest<CheckOTPResponse>;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.UserFeatures.Commands;

public record ToggleUserActivityCommand(ToggleUserActivityRequest command) : IRequest<ToggleUserActivityResponse>;
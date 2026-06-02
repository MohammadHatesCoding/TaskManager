using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.UserFeatures.Commands;

public record UpdateMyProfileCommand(UpdateMyProfileRequest command) : IRequest<UpdateMyProfileResponse>;
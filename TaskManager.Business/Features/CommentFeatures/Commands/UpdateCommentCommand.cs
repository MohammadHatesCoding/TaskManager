using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.CommentFeatures.Commands;

public record UpdateCommentCommand(UpdateCommentRequest command) : IRequest<UpdateCommentResponse>;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.CommentFeatures.Commands;

public record CreateCommentCommand(CreateCommentRequest command) : IRequest<CreateCommentResponse>;
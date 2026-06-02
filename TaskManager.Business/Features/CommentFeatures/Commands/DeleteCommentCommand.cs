using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.CommentFeatures.Commands;

public record DeleteCommentCommand(DeleteCommentRequest command) : IRequest<DeleteCommentResponse>;
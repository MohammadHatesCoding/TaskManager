using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.CommentFeatures.Queries;

public record GetCommentDetailsQuery(GetCommentDetailsRequest query) : IRequest<GetCommentDetailsResponse>;
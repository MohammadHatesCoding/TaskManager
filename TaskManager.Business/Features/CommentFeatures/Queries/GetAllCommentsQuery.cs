using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.CommentFeatures.Queries;

public record GetAllCommentsQuery(GetAllCommentsRequest query) : IRequest<List<GetAllCommentsResponse>>;
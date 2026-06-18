using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.CommentFeatures.Queries;

public class GetAllCommentsQueryValidator : AbstractValidator<GetAllCommentsQuery>
{
    public GetAllCommentsQueryValidator()
    {

    }
}

public record GetAllCommentsQuery(GetAllCommentsRequest query) : IRequest<List<GetAllCommentsResponse>>;
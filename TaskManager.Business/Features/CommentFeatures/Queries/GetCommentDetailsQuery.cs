using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.CommentFeatures.Queries;

public class GetCommentDetailsQueryValidator : AbstractValidator<GetCommentDetailsQuery>
{
    public GetCommentDetailsQueryValidator()
    {
        RuleFor(x => x.query.Id)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);
    }
}

public record GetCommentDetailsQuery(GetCommentDetailsRequest query) : IRequest<GetCommentDetailsResponse>;
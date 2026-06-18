using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.UserFeatures.Queries;

public class GetUserDetailsQueryValidator : AbstractValidator<GetUserDetailsQuery>
{
    public GetUserDetailsQueryValidator()
    {
        RuleFor(x => x.query.Id)
            .NotEmpty();
    }
}

public record GetUserDetailsQuery(GetProfileDetailsRequest query) : IRequest<GetUserDetailsResponse>;
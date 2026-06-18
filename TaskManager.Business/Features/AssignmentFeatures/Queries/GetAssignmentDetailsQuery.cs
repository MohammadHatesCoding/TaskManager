using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.AssignmentFeatures.Queries;

public class GetAssignmentDetailsQueryValidator : AbstractValidator<GetAssignmentDetailsQuery>
{
    public GetAssignmentDetailsQueryValidator()
    {
        RuleFor(x => x.query.Id)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);
    }


}


public record GetAssignmentDetailsQuery(GetAssignmentDetailsRequest query) : IRequest<GetAssignmentDetailsResponse>;
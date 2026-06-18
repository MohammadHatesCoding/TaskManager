using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.AssignmentEmployeeFeatures.Queries;

public class GetAssignmentEmployeeDetailsQueryValidator : AbstractValidator<GetAssignmentEmployeeDetailsQuery>
{
    public GetAssignmentEmployeeDetailsQueryValidator()
    {
        RuleFor(x => x.query.Id)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);
    }
}

public record GetAssignmentEmployeeDetailsQuery(GetAssignmentEmployeeDetailsRequest query) : IRequest<GetAssignmentEmployeeDetailsResponse>;
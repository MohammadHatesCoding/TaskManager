using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Features.EmployeeFeatures.Commands;

namespace TaskManager.Business.Features.EmployeeFeatures.Queries;

public class GetEmployeeDetailsQueryValidator : AbstractValidator<GetEmployeeDetailsQuery>
{
    public GetEmployeeDetailsQueryValidator()
    {
        RuleFor(x => x.query.EmployeeId)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);
    }
}

public record GetEmployeeDetailsQuery(GetEmployeeDetailsRequest query) : IRequest<GetEmployeeDetailsResponse>;
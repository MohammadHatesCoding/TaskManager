using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.ProjectEmployeeFeatures.Queries;

public class GetProjectEmployeeDetailsQueryValidator : AbstractValidator<GetProjectEmployeeDetailsQuery>
{
    public GetProjectEmployeeDetailsQueryValidator()
    {
        RuleFor(x => x.query.Id)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);
    }
}

public record GetProjectEmployeeDetailsQuery(GetProjectEmployeeDetailsRequest query) : IRequest<GetProjectEmployeeDetailsResponse>;
using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.DepartmentFeatures.Queries;

public class GetDepartmentDetailsQueryValidator : AbstractValidator<GetDepartmentDetailsQuery>
{
    public GetDepartmentDetailsQueryValidator()
    {
        RuleFor(x => x.query.Id)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);
    }
}

public record GetDepartmentDetailsQuery(GetDepartmentDetailsRequest query) : IRequest<GetDepartmentDetailsResponse>;
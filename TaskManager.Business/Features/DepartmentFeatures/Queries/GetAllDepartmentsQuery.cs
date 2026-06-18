using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.DepartmentFeatures.Queries;

public class GetAllDepartmentsQueryValidator : AbstractValidator<GetAllDepartmentsQuery>
{
    public GetAllDepartmentsQueryValidator()
    {

    }
}

public record GetAllDepartmentsQuery(GetAllDepartmentsRequest query) : IRequest<List<GetAllDepartmentsResponse>>;
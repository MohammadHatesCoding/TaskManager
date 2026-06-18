using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.EmployeeFeatures.Queries;

public class GetAllEmployeesQueryValidator : AbstractValidator<GetAllEmployeesQuery>
{
    public GetAllEmployeesQueryValidator()
    {

    }
}

public record GetAllEmployeesQuery(GetAllEmployeesRequest query) : IRequest<List<GetAllEmployeesResponse>>;
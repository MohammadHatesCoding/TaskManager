using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.ProjectEmployeeFeatures.Queries;

public class GetAllProjectEmployeesQueryValidator : AbstractValidator<GetAllProjectEmployeesQuery>
{
    public GetAllProjectEmployeesQueryValidator()
    {

    }
}

public record GetAllProjectEmployeesQuery(GetAllProjectEmployeesRequest query) : IRequest<List<GetAllProjectEmployeesResponse>>;
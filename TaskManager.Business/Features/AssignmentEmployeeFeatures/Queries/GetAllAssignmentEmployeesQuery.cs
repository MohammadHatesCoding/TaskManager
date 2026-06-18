using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.AssignmentEmployeeFeatures.Queries;

public class GetAllAssignmentEmployeesQueryValidator : AbstractValidator<GetAllAssignmentEmployeesQuery>
{
    public GetAllAssignmentEmployeesQueryValidator()
    {

    }
}

public record GetAllAssignmentEmployeesQuery(GetAllAssignmentEmployeesRequest query) : IRequest<List<GetAllAssignmentEmployeesResponse>>;
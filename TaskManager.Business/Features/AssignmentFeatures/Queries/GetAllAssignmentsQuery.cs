using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.AssignmentFeatures.Queries;

public class GetAllAssignmentsQueryValidator : AbstractValidator<GetAllAssignmentsQuery>
{
    public GetAllAssignmentsQueryValidator()
    {

    }
}

public record GetAllAssignmentsQuery(GetAllAssignmentsRequest query) : IRequest<List<GetAllAssignmentsResponse>>;
using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.ProjectFeatures.Queries;

public class GetAllProjectsQueryValidator : AbstractValidator<GetAllProjectsQuery>
{
    public GetAllProjectsQueryValidator()
    {

    }
}

public record GetAllProjectsQuery(GetAllProjectsRequest query) : IRequest<List<GetAllProjectsResponse>>;
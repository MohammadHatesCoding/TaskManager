using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.UserFeatures.Queries;

public class GetAllUsersQueryValidator : AbstractValidator<GetAllUsersQuery>
{
    public GetAllUsersQueryValidator()
    {

    }
}

public record GetAllUsersQuery(GetAllUsersRequest query) : IRequest<List<GetAllUsersResponse>>;
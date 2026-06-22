using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.UserFeatures.Queries;

public class GetProfileDetailsQueryValidator : AbstractValidator<GetProfileDetailsQuery>
{
    public GetProfileDetailsQueryValidator()
    {
    
    }
}

public record GetProfileDetailsQuery(GetProfileDetailsRequest query) : IRequest<GetProfileDetailsResponse>;
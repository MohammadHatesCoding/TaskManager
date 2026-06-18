using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.AuthFeatures.Commands;

public class RefreshCommandValidator : AbstractValidator<RefreshCommand>
{
    public RefreshCommandValidator()
    {
        RuleFor(x => x.command.RefreshToken)
            .NotEmpty();

        RuleFor(x => x.command.UserId)
            .NotEmpty();
    }
}

public record RefreshCommand(RefreshRequest command) : IRequest<RefreshResponse>;
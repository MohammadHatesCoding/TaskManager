using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.AuthFeatures.Commands;

public class CheckOTPCommandValidator : AbstractValidator<CheckOTPCommand>
{
    public CheckOTPCommandValidator()
    {
        RuleFor(x => x.command.username)
            .NotEmpty();

        RuleFor(x => x.command.otp)
            .NotEmpty();
    }
}

public record CheckOTPCommand(CheckOTPRequest command) : IRequest<CheckOTPResponse>;
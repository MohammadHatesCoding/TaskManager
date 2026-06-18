using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.AuthFeatures.Commands;

public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
{
    public ResetPasswordCommandValidator()
    {
        RuleFor(x => x.command.RawResetPasswordToken)
            .NotEmpty();

        RuleFor(x => x.command.Password)
            .NotEmpty()
            .MinimumLength(8);

        RuleFor(x => x.command.ConfirmPassword)
            .NotEmpty()
            .MaximumLength(8)
            .Equal(x => x.command.Password);
    }
}

public record ResetPasswordCommand(ResetPasswordRequest command) : IRequest<ResetPasswordResponse>;
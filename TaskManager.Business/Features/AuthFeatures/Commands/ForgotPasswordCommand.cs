using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.AuthFeatures.Commands;

public class ForgotPasswordCommandValidator : AbstractValidator<ForgotPasswordCommand>
{
    public ForgotPasswordCommandValidator()
    {
        RuleFor(x => x.command.Username)
            .NotEmpty()
            .NotNull();
    }
}

public record ForgotPasswordCommand(ForgotPasswordRequest command) : IRequest<ForgotPasswordResponse>;
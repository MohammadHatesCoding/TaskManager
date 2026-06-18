using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.AuthFeatures.Commands;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.command.Username)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.command.Password)
            .NotEmpty()
            .NotNull();
    }
}

public record LoginCommand(LoginRequest command) : IRequest<LoginResponse>;
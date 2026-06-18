using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.AuthFeatures.Commands;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.command.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.command.LastName)
            .NotEmpty()
            .MaximumLength(700);

        RuleFor(x => x.command.NationalCode)
            .NotEmpty()
            .MaximumLength(10);

        RuleFor(x => x.command.Username)
            .NotEmpty();

        RuleFor(x => x.command.Email)
            .NotEmpty();

        RuleFor(x => x.command.PhoneNumber)
            .NotEmpty()
            .MaximumLength(13);
    }
}

public record RegisterCommand(RegisterRequest command) : IRequest<RegisterResponse>;
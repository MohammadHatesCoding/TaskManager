using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.AuthFeatures.Commands;

public class CreatePasswordCommandValidator : AbstractValidator<CreatePasswordCommand>
{
    public CreatePasswordCommandValidator()
    {
        RuleFor(x => x.command.UserId)
            .NotEmpty();

        RuleFor(x => x.command.Password)
            .NotEmpty()
            .MinimumLength(0);

        RuleFor(x => x.command.ConfirmPassword)
            .NotEmpty()
            .MinimumLength(0)
            .Equal(x => x.command.Password);
    }
}


public record CreatePasswordCommand(CreatePasswordRequest command) : IRequest<CreatePasswordResponse>;
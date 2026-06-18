using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.AuthFeatures.Commands;

public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
{
    public ChangePasswordCommandValidator()
    {
        RuleFor(x => x.command.OldPassword)
            .NotEmpty();

        RuleFor(x => x.command.NewPassword)
            .NotEmpty()
            .MinimumLength(8)
            .NotEqual(x => x.command.OldPassword);

        RuleFor(x => x.command.ConfirmNewPassword)
            .NotEmpty()
            .MinimumLength(8)
            .Equal(x => x.command.NewPassword);
    }
}

public record ChangePasswordCommand(ChangePasswordRequest command) : IRequest<ChangePasswordResponse>;
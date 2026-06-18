using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.UserFeatures.Commands;

public class UpdateMyProfileCommandValidator : AbstractValidator<UpdateMyProfileCommand>
{
    public UpdateMyProfileCommandValidator()
    {
        RuleFor(x => x.command.Id)
            .NotEmpty();

        RuleFor(x => x.command.Name)
            .NotEmpty()
            .MaximumLength(150);

        RuleFor(x => x.command.LastName)
            .NotEmpty()
            .MaximumLength(150);

        RuleFor(x => x.command.NationalCode)
            .NotEmpty()
            .MaximumLength(10);

        RuleFor(x => x.command.BirthDate)
            .NotNull();

        RuleFor(x => x.command.Email)
            .NotEmpty();

        RuleFor(x => x.command.PhoneNumber)
            .NotEmpty()
            .MaximumLength(13);

        RuleFor(x => x.command.Username)
            .NotEmpty();
    }
}

public record UpdateMyProfileCommand(UpdateMyProfileRequest command) : IRequest<UpdateMyProfileResponse>;
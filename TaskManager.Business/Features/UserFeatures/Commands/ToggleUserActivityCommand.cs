using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.UserFeatures.Commands;

public class ToggleUserActivityCommandValidator : AbstractValidator<ToggleUserActivityCommand>
{
    public ToggleUserActivityCommandValidator()
    {
        RuleFor(x => x.command.Id)
            .NotEmpty();
    }
}

public record ToggleUserActivityCommand(ToggleUserActivityRequest command) : IRequest<ToggleUserActivityResponse>;
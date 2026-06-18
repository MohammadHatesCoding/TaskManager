using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.DepartmentFeatures.Commands;

public class UpdateDepartmentCommandValidator : AbstractValidator<UpdateDepartmentCommand>
{
    public UpdateDepartmentCommandValidator()
    {
        RuleFor(x => x.command.Id)
            .NotNull()
            .GreaterThan(0);

        RuleFor(x => x.command.Title)
            .NotEmpty()
            .NotNull()
            .MaximumLength(100);

        RuleFor(x => x.command.CompanyId)
            .NotNull()
            .GreaterThan(0);
    }
}

public record UpdateDepartmentCommand(UpdateDepartmentRequest command) : IRequest<UpdateDepartmentResponse>;
using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.DepartmentFeatures.Commands;

public class CreateDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommand>
{
    public CreateDepartmentCommandValidator()
    {
        RuleFor(x => x.command.Title)
            .NotEmpty()
            .NotNull()
            .MaximumLength(100);

        RuleFor(x => x.command.CompanyId)
            .NotNull()
            .GreaterThan(0);
    }
}

public record CreateDepartmentCommand(CreateDepartmentRequest command) : IRequest<CreateDepartmentResponse>;
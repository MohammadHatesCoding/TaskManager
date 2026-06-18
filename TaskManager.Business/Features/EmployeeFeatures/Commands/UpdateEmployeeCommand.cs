using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.EmployeeFeatures.Commands;

public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
{
    public UpdateEmployeeCommandValidator()
    {
        RuleFor(x => x.command.Id)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);

        RuleFor(x => x.command.PersonnelCode)
            .NotEmpty();

        RuleFor(x => x.command.UserId)
            .NotEmpty();

        RuleFor(x => x.command.Salary)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.command.UserId)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);

        RuleFor(x => x.command.CompanyId)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);
    }
}

public record UpdateEmployeeCommand(UpdateEmployeeRequest command) : IRequest<UpdateEmployeeResponse>;
using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.EmployeeFeatures.Commands;

public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {
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

public record CreateEmployeeCommand(CreateEmployeeRequest command) : IRequest<CreateEmployeeResponse>;
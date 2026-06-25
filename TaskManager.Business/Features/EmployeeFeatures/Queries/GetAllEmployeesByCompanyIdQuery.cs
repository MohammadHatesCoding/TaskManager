using FluentValidation;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Business.Features.EmployeeFeatures.Queries;

public class GetAllEmployeesByCompanyIdQueryValidator : AbstractValidator<GetAllEmployeesByCompanyIdQuery>
{
    public GetAllEmployeesByCompanyIdQueryValidator()
    {

    }
}

public record GetAllEmployeesByCompanyIdQuery(GetAllEmployeesByCompanyIdRequest query) : IRequest<List<GetAllEmployeesByCompanyIdResponse>>;
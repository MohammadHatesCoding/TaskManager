using AutoMapper;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;
using TaskManager.Domain.Models;

namespace TaskManager.Business.Features.CompanyFeatures.Commands;

public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, CreateCompanyResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public CreateCompanyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateCompanyResponse> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var company = _mapper.Map<Company>(request.command);

            await _unitOfWork.CompanyRepository.CreateAsync(company);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new CreateCompanyResponse(Id: company.Id);
        }
        catch (Exception ex) 
        {
            throw new Exception(message: ex.Message);
        }
    }
}

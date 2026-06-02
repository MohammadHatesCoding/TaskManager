using AutoMapper;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;
using TaskManager.Domain.Models;

namespace TaskManager.Business.Features.CompanyFeatures.Commands;

public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, UpdateCompanyResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateCompanyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<UpdateCompanyResponse> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var company = await _unitOfWork.CompanyRepository.GetByIdAsync(request.command.Id);

            company = _mapper.Map<Company>(request.command);

            await _unitOfWork.CompanyRepository.UpdateAsync(company);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new UpdateCompanyResponse(Id: company.Id);
        }
        catch (Exception ex) 
        {
            throw new Exception(message: ex.Message);
        }
    }
}

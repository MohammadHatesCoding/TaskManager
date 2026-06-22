using AutoMapper;
using TaskManager.Business.Abstraction.Data;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;

namespace TaskManager.Business.Features.UserFeatures.Queries;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<GetAllUsersResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetAllUsersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<GetAllUsersResponse>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var parameters = new CustomDynamicParameters();

            var models = await _unitOfWork.ReadDbConnection.QueryAsync<GetAllUsersResponse>("GetAllUsers", parameters, null, System.Data.CommandType.StoredProcedure);

            var users = _mapper.Map<List<GetAllUsersResponse>>(models);

            return users.ToList();
        }
        catch (Exception ex)
        {
            throw new Exception(message: ex.Message);
        }
    }
}
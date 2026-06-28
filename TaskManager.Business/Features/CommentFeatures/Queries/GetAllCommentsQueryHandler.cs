using AutoMapper;
using TaskManager.Business.Abstraction.Data;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;
using TaskManager.Business.Features.DepartmentFeatures.Queries;

namespace TaskManager.Business.Features.CommentFeatures.Queries;

public class GetAllCommentsQueryHandler : IRequestHandler<GetAllCommentsQuery, List<GetAllCommentsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetAllCommentsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<GetAllCommentsResponse>> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var parameters = new CustomDynamicParameters();

            var comments = await _unitOfWork.ReadDbConnection.QueryAsync<GetAllCommentsResponse>("GetAllComments", parameters, null, System.Data.CommandType.StoredProcedure);

            return comments.ToList();
        }
        catch (Exception ex)
        {
            throw new Exception(message: ex.Message);
        }
    }
}
using AutoMapper;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;

namespace TaskManager.Business.Features.CommentFeatures.Queries;

public class GetCommentDetailsQueryHandler : IRequestHandler<GetCommentDetailsQuery, GetCommentDetailsResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetCommentDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetCommentDetailsResponse> Handle(GetCommentDetailsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var model = await _unitOfWork.CommentRepository.GetByIdAsync(request.query.Id);

            var comment = _mapper.Map<GetCommentDetailsResponse>(model);

            return comment;
        }
        catch (Exception ex)
        {
            throw new Exception(message: ex.Message);
        }
    }
}
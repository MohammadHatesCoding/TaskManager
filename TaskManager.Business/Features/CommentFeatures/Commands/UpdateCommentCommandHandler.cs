using AutoMapper;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;
using TaskManager.Domain.Models;

namespace TaskManager.Business.Features.CommentFeatures.Commands;

public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, UpdateCommentResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateCommentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<UpdateCommentResponse> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var comment = await _unitOfWork.CommentRepository.GetByIdAsync(request.command.Id);

            comment = _mapper.Map<Comment>(request.command);

            await _unitOfWork.CommentRepository.UpdateAsync(comment);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new UpdateCommentResponse(Id: comment.Id);
        }
        catch (Exception ex) 
        {
            throw new Exception(message: ex.Message);
        }
    }
}

using AutoMapper;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;
using TaskManager.Domain.Models;

namespace TaskManager.Business.Features.CommentFeatures.Commands;

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, CreateCommentResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public CreateCommentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateCommentResponse> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var comment = _mapper.Map<Comment>(request.command);

            await _unitOfWork.CommentRepository.CreateAsync(comment);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new CreateCommentResponse(Id: comment.Id);
        }
        catch (Exception ex) 
        {
            throw new Exception(message: ex.Message);
        }
    }
}
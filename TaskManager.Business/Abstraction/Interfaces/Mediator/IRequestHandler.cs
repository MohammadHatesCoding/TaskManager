namespace TaskManager.Business.Abstraction.Interfaces.Mediator;

public interface IRequestHandler<TRequest, TResponse> 
    where TRequest : IRequest<TResponse>
{
    Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}

namespace TaskManager.Business.Abstraction.Interfaces.Mediator;

public interface IDispatcher
{
    Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken);
}

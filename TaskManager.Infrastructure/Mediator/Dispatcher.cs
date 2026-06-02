using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Infrastructure.Mediator;

public class Dispatcher : IDispatcher
{
    private readonly IServiceProvider _serviceProvider;
    //private readonly Dictionary<Type, object> _handlers = new();
    public Dispatcher(IServiceProvider serviceProvider/*, Assembly[]? assemblies = null*/)
    {
        //assemblies ??= new[] { Assembly.GetExecutingAssembly() }; // fallback

        //foreach (var assembly in assemblies)
        //{
        //    var handlerTypes = assembly.GetTypes()
        //        .Where(t => t.GetInterfaces()
        //            .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)));

        //    foreach (var handlerType in handlerTypes)
        //    {
        //        var handlerInterface = handlerType.GetInterfaces()
        //            .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>));

        //        var handlerInstance = serviceProvider.GetRequiredService(handlerType);

        //        var requestType = handlerInterface.GenericTypeArguments[0];
        //        _handlers[requestType] = handlerInstance;
        //    }
        //}

        _serviceProvider = serviceProvider;
    }
    public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken)
    {
        //var requestType = request.GetType();
        //if (_handlers.TryGetValue(requestType, out var handlerObj))
        //{
        //    dynamic dynHandler = handlerObj;
        //    dynamic dynRequest = request;
        //    return dynHandler.Send(dynRequest);
        //}

        //throw new Exception($"Handler not found for {requestType.Name}");

        var requestType = request.GetType();
        var handlerInterfaceType = typeof(IRequestHandler<,>).MakeGenericType(requestType, typeof(TResponse));
        var handler = _serviceProvider.GetService(handlerInterfaceType);

        if (handler == null)
        {
            throw new Exception($"Handler not found for {requestType.Name}");
        }

        var handleMethod = handler.GetType().GetMethod("Handle");
        if (handleMethod == null)
        {
            throw new Exception($"Handle method not found on handler for {requestType.Name}");
        }

        var result = handleMethod.Invoke(handler, new object[] { request, cancellationToken });

        return (Task<TResponse>)result;
    }
}

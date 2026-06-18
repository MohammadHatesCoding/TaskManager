using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Business.Abstraction.Interfaces.Mediator;

namespace TaskManager.Infrastructure.Mediator;

public class Dispatcher : IDispatcher
{
    private readonly IServiceProvider _serviceProvider;
    public Dispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken)
    {
        var requestType = request.GetType();

        var validatorType = typeof(IValidator<>)
                    .MakeGenericType(requestType);

        var validators = _serviceProvider
            .GetServices(validatorType);

        foreach (var validator in validators)
        {
            var validateMethod = validator.GetType()
                .GetMethod("ValidateAsync", new[]
                {
                    requestType,
                    typeof(CancellationToken)
                });

            if (validateMethod is not null)
            {
                var validationTask =
                    (Task)validateMethod.Invoke(
                        validator,
                        new object[]
                        {
                            request,
                            cancellationToken
                        })!;

                await validationTask;

                var resultProperty = validationTask
                    .GetType()
                    .GetProperty("Result");

                var validationResult =
                    resultProperty?.GetValue(validationTask);

                var isValidProperty = validationResult?
                    .GetType()
                    .GetProperty("IsValid");

                var isValid =
                    (bool)(isValidProperty?.GetValue(validationResult) ?? true);

                if (!isValid)
                {
                    var errorsProperty = validationResult!
                        .GetType()
                        .GetProperty("Errors");

                    var errors =
                        (IEnumerable<object>)errorsProperty!
                            .GetValue(validationResult)!;

                    var messages = errors
                        .Select(x =>
                            x.GetType()
                             .GetProperty("ErrorMessage")!
                             .GetValue(x)?
                             .ToString());

                    throw new ValidationException(
                        string.Join(Environment.NewLine, messages));
                }
            }
        }

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

        return await (Task<TResponse>)result;
    }
}

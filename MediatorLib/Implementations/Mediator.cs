using MediatorLib.Abstractions;

namespace MediatorLib.Implementations;

public class Mediator : IMediator
{
    private readonly IServiceProvider _serviceProvider;

    public Mediator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public TResponse Send<TResponse>(IRequest<TResponse> request)
    {
        var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
        var handler = _serviceProvider.GetService(handlerType);

        if (handler == null)
        {
            throw new InvalidOperationException($"No handler found for {request.GetType().Name}");
        }

        return (TResponse)handlerType
            .GetMethod("Handle")!
            .Invoke(handler, new object[] { request })!;
    }
}


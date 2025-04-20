namespace MediatorWebExample.MediatorLib;

public class Mediator(IServiceProvider serviceProvider)
{
    public async Task<TResponse> Execute<TCommand, TResponse>(TCommand command)
    {
        using var scope = serviceProvider.CreateScope();
        var handler = scope.ServiceProvider.GetRequiredService<IRequestHandler<TCommand, TResponse>>();

        return await handler.Handle(command);
    }
}

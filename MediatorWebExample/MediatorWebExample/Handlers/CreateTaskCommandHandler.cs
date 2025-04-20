using MediatorWebExample.Commands;
using MediatorWebExample.MediatorLib;

namespace MediatorWebExample.Handlers;

public class CreateTaskCommandHandler : IRequestHandler<CommandRequest, CommandResponse>
{
    public async Task<CommandResponse> Handle(CommandRequest request, CancellationToken cancellationToken = default)
    {
        await Task.Delay(1000);

        return new CommandResponse
        {
            Response = "Hello World"
        };
    }
}

using MediatorWebExample.Commands;
using MediatorWebExample.MediatorLib;

namespace MediatorWebExample.Handlers;

public class UpdateTaskCommandHandler : IRequestHandler<UpdateReq, UpdateRes>
{
    public async Task<UpdateRes> Handle(UpdateReq request, CancellationToken cancellationToken = default)
    {
        await Task.Delay(1000);

        return new UpdateRes
        {
            Response = request.Request
        };
    }
}

using MediatorWebExample.Commands;
using MediatorWebExample.MediatorLib;
using Microsoft.AspNetCore.Mvc;

namespace MediatorWebExample.Controllers;

[ApiController]
[Route("[controller]")]
public class TasksController(Mediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> CreateTask()
    {
        var res = await mediator.Execute<CommandRequest, CommandResponse>(new CommandRequest { Request = "Hello" });

        return Ok(res.Response);
    }

    [HttpGet("/update")]
    public async Task<IActionResult> UpdateTask()
    {
        var res = await mediator.Execute<UpdateReq, UpdateRes>(new UpdateReq { Request = "update" });

        return Ok(res.Response);
    }
}

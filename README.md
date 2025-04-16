# Example usage

```csharp
public class CreateOrderCommand : IRequest<string>
{
    public string Product { get; set; }
    public int Quantity { get; set; }
}

public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, string>
{
    public string Handle(CreateOrderCommand request)
    {
        return $"Order created for {request.Quantity} x {request.Product}";
    }
}

[...]
[...]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public IActionResult Create()
    {
        var result = _mediator.Send(new CreateOrderCommand
        {
            Product = "Book",
            Quantity = 3
        });

        return Ok(result);
    }
}
```

Program.cs

```csharp
builder.Services.AddTransient<IMediator, Mediator>();
builder.Services.AddTransient<IRequestHandler<CreateOrderCommand, string>, CreateOrderHandler>();
```

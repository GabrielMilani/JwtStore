using JwtStore.Order.Commands;
using JwtStore.Order.Handlers;
using JwtStore.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace JwtStore.Api.Controllers;

[ApiController]
public class OrderControllers : ControllerBase
{
    [HttpPost("v1/order/open")]
    public ICommandResult Post([FromBody] OrderCreateCommand command,
                               [FromServices] OrderCreateHandler handler)
    {
        return (ICommandResult)handler.Handle(command);
    }
    [HttpPost("v1/order/items")]
    public ICommandResult Put([FromBody] OrderItemsInsertCommand command,
                              [FromServices] OrderItemsInsertHandler handler)
    {
        return (ICommandResult)handler.Handle(command);
    }
    [HttpPost("v1/order/payment")]
    public ICommandResult Put([FromBody] OrderPaymentCommand command,
                              [FromServices] OrderPaymentHandler handler)
    {
        return (ICommandResult)handler.Handle(command);
    }
    [HttpPost("v1/order/close")]
    public ICommandResult Put([FromBody] OrderCloseCommand command,
                              [FromServices] OrderCloseHandler handler)
    {
        return (ICommandResult)handler.Handle(command);
    }
}
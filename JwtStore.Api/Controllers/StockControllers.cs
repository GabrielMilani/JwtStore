using JwtStore.Stock.Commands;
using JwtStore.Stock.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace JwtStore.Api.Controllers;

[ApiController]
public class StockControllers : ControllerBase
{
    [HttpPost("v1/stock/categories")]
    public CommandResultStock Post([FromBody] CategoryCreateCommand command,
                                   [FromServices] CategoryCreateHandler handler)
    {
        return (CommandResultStock)handler.Handle(command);
    }
    [HttpPost("v1/stock/products")]
    public CommandResultStock Post([FromBody] ProductCreateCommand command,
                                   [FromServices] ProductCreateHandler handler)
    {
        return (CommandResultStock)handler.Handle(command);
    }


}
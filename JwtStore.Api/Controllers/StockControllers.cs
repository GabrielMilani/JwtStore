using JwtStore.Shared.Commands;
using JwtStore.Stock.Commands;
using JwtStore.Stock.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtStore.Api.Controllers;

[Authorize]
[ApiController]
public class StockControllers : ControllerBase
{
    [HttpPost("v1/stock/categories")]
    public CommandResult Post([FromBody] CategoryCreateCommand command,
                                   [FromServices] CategoryCreateHandler handler)
    {
        return (CommandResult)handler.Handle(command);
    }
    [HttpPost("v1/stock/products")]
    public CommandResult Post([FromBody] ProductCreateCommand command,
                                   [FromServices] ProductCreateHandler handler)
    {
        return (CommandResult)handler.Handle(command);
    }


}
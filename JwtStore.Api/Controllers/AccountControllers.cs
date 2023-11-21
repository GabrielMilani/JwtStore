using JwtStore.Account.Commands;
using JwtStore.Account.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace JwtStore.Api.Controllers;

[ApiController]
public class AccountControllers : ControllerBase
{
    [HttpPost("v1/accounts")]
    public CommandResult Post([FromBody] AccountCreateCommand command,
                              [FromServices] AccountCreateHandler handler)
    {
        return (CommandResult)handler.Handle(command);
    }
    [HttpGet("v1/accounts")]
    public CommandResult Get([FromBody] AccountAuthenticateCommand command,
                             [FromServices] AccountAuthenticateHandler handler)
    {
        return (CommandResult)handler.Handle(command);
    }
}
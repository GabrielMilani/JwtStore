using JwtStore.Account.Commands;
using JwtStore.Account.Handlers;
using JwtStore.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace JwtStore.Api.Controllers;

[ApiController]
public class AccountControllers : ControllerBase
{
    [HttpPost("v1/accounts")]
    public CommandResult Post([FromBody] AccountCreateUserCommand userCommand,
        [FromServices] AccountCreateUserHandler userHandler)
    {
        return (CommandResult)userHandler.Handle(userCommand);
    }

    [HttpGet("v1/accounts")]
    public CommandResult Get([FromBody] AccountAuthenticateCommand command,
        [FromServices] AccountAuthenticateHandler handler)
    {
        return (CommandResult)handler.Handle(command);
    }

    [HttpPost("v1/accounts/roles")]
    public CommandResult Get([FromBody] AccountCreateRoleCommand command,
                            [FromServices] AccountCreateRoleHandler handler)
    {
        return (CommandResult)handler.Handle(command);
    }
    [HttpPut("v1/accounts/roles")]
    public CommandResult Get([FromBody] AccountInsertRoleCommand command,
                            [FromServices] AccountInsertRoleHandler handler)
    {
        return (CommandResult)handler.Handle(command);
    }
}
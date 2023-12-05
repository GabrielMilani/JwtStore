using JwtStore.Account.Commands;
using JwtStore.Account.Commands.Results;
using JwtStore.Account.Handlers;
using JwtStore.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace JwtStore.Api.Controllers;

[ApiController]
public class AccountControllers : ControllerBase
{
    #region Create account
    [HttpPost("v1/accounts")]
    public ICommandResult Post([FromBody] UserCreateCommand userCommand,
                               [FromServices] UserCreateHandler userHandler)
    {
        return (UserCommandResult)userHandler.Handle(userCommand);
    }
    #endregion

    #region Login account
    [HttpGet("v1/accounts")]
    public ICommandResult Get([FromBody] AuthenticateCommand command,
                              [FromServices] AuthenticateHandler handler)
    {
        return (AuthenticateCommandResult)handler.Handle(command);
    }
    #endregion

    #region Insert Roles in Users
    [HttpPut("v1/accounts/roles")]
    public ICommandResult Get([FromBody] RoleInsertCommand command,
                              [FromServices] RoleInsertHandler handler)
    {
        return (RoleCommandResult)handler.Handle(command);
    }
    #endregion


}
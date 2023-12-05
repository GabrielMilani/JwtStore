using JwtStore.Account.Commands;
using JwtStore.Account.Commands.Results;
using JwtStore.Account.Commands.Results.Response;
using JwtStore.Account.Handlers;
using JwtStore.Account.Repositories;
using JwtStore.Infra.Data;
using JwtStore.Shared.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JwtStore.Api.Controllers;

public class RoleControllers : ControllerBase
{
    [HttpPost("v1/roles")]
    public ICommandResult Post([FromBody] AccountCreateRoleCommand command,
                               [FromServices] AccountCreateRoleHandler handler)
    {
        return (AccountRoleCommandResult)handler.Handle(command);
    }

    [HttpGet("v1/roles")]
    public ICommandResult Get([FromServices] AppDbContext context)
    {
        var roles = context.Roles.AsNoTracking().ToListAsync().Result;
        var listRoleResponse = new List<RoleResponse>();
        foreach (var role in roles)
        {
            listRoleResponse.Add(new RoleResponse(role.Id, role.Title));
        }
        return new AccountRoleCommandResult(true, "Role List", listRoleResponse);
    }
    [HttpGet("v1/roles/{id:int}")]
    public ICommandResult GetById([FromRoute] int id,
                                  [FromServices] IAccountSelectRoleRepository roleSelect)
    {
        var role = roleSelect.GetById(id).Result;
        if (role is null)
            return new CommandResult(false, "Role search failed");
        var listRoleResponse = new List<RoleResponse>();
        listRoleResponse.Add(new RoleResponse(role.Id, role.Title));
        return new AccountRoleCommandResult(true, "Role", listRoleResponse);
    }

}
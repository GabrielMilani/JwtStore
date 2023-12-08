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

[ApiController]
public class RoleControllers : ControllerBase
{

    #region Create role
    [HttpPost("v1/roles")]
    public ICommandResult Post([FromBody] RoleCreateCommand command,
                               [FromServices] RoleCreateHandler handler)
    {
        return (ICommandResult)handler.Handle(command);
    }
    #endregion

    #region Select all roles

    [HttpGet("v1/roles")]
    public ICommandResult Get([FromServices] AppDbContext context)
    {
        var roles = context.Roles.AsNoTracking().ToListAsync().Result;
        var listRoleResponse = new List<RoleResponse>();
        foreach (var role in roles)
        {
            listRoleResponse.Add(new RoleResponse(role.Id, role.Title));
        }
        return new RoleCommandResult(true, "Role List", listRoleResponse);
    }

    #endregion

    #region Select role by Id

    [HttpGet("v1/roles/{id:int}")]
    public ICommandResult GetById([FromRoute] int id,
                                  [FromServices] IRoleSelectRepository roleSelect)
    {
        var role = roleSelect.GetById(id).Result;
        if (role is null)
            return new CommandResult(false, "Role search failed");
        var listRoleResponse = new List<RoleResponse>();
        listRoleResponse.Add(new RoleResponse(role.Id, role.Title));
        return new RoleCommandResult(true, "Role", listRoleResponse);
    }

    #endregion

}
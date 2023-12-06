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

public class AddressControllers : ControllerBase
{
    #region Create Address
    [HttpPost("v1/addresses")]
    public ICommandResult Post([FromBody] AddressCreateCommand command,
                               [FromServices] AddressCreateHandler handler)
    {
        return (RoleCommandResult)handler.Handle(command);
    }
    #endregion

    #region Select all Address

    [HttpGet("v1/addresses")]
    public ICommandResult Get([FromServices] AppDbContext context)
    {
        var addresses = context.Addresses.AsNoTracking().ToListAsync().Result;
        var listAddressResponse = new List<AddressResponse>();
        foreach (var address in addresses)
        {
            listAddressResponse.Add(new AddressResponse(address.Id, address.Street, address.Number, address.Neighborhood,
                                                        address.City, address.State, address.Country, address.ZipCode));
        }
        return new AddressCommandResult(true, "Role List", listAddressResponse);
    }

    #endregion

    #region Select role by Id

    [HttpGet("v1/addresses/{id:int}")]
    public ICommandResult GetById([FromRoute] int id,
                                  [FromServices] IAddressSelectRepository addressSelect)
    {
        var address = addressSelect.GetById(id).Result;
        if (address is null)
            return new CommandResult(false, "Address search failed");
        var listAddressResponse = new List<AddressResponse>();
        listAddressResponse.Add(new AddressResponse(address.Id, address.Street, address.Number, address.Neighborhood,
                                                    address.City, address.State, address.Country, address.ZipCode));
        return new AddressCommandResult(true, "Address", listAddressResponse);
    }

    #endregion
}
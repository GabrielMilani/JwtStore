using Flunt.Notifications;
using JwtStore.Account.Commands;
using JwtStore.Account.Commands.Results;
using JwtStore.Account.Commands.Results.Response;
using JwtStore.Account.Entities;
using JwtStore.Account.Repositories;
using JwtStore.Shared.Commands;
using JwtStore.Shared.Handlers;

namespace JwtStore.Account.Handlers;

public class AddressCreateHandler : Notifiable<Notification>, IHandler<AddressCreateCommand>
{
    private readonly IAddressCreateRepository _addressCreateRepository;

    public AddressCreateHandler(IAddressCreateRepository addressCreateRepository)
    {
        _addressCreateRepository = addressCreateRepository;
    }

    public ICommandResult Handle(AddressCreateCommand command)
    {
        #region 01. Valida a requisição.
        try
        {
            command.Validate();
            if (!command.IsValid)
                return new CommandResult(false, "Ops, falha ao cadastrar Role!", command.Notifications);
        }
        catch
        {
            return new CommandResult(false, "Ops, falha ao verificar requisição!", command.Notifications);
        }
        #endregion

        #region 02. Recebe dados Address.
        Address address;
        try
        {
            address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State,
                                  command.Country, command.ZipCode, command.UserId);
        }
        catch
        {
            return new CommandResult(false, "Ops, falha ao verificar requisição!", command.Notifications);
        }
        #endregion

        #region Persiste endereço no banco de dados.
        try
        {
            _addressCreateRepository.SaveAsync(address);
        }
        catch
        {
            return new CommandResult(false, "Address save failed!");
        }
        #endregion

        var addressResponse = new AddressResponse(address.Id, address.Street, address.Number, address.Neighborhood, address.City,
                                                  address.State, address.Country, address.ZipCode);
        var listAddressResponse = new List<AddressResponse>();
        listAddressResponse.Add(addressResponse);

        return new AddressCommandResult(true, "Create address success!", listAddressResponse);
    }
}
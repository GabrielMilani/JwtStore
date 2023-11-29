using Flunt.Notifications;
using JwtStore.Account.Commands;
using JwtStore.Account.Entities;
using JwtStore.Account.Repositories;
using JwtStore.Shared.Commands;
using JwtStore.Shared.Handlers;

namespace JwtStore.Account.Handlers;

public class AccountRoleCreateHandler : Notifiable<Notification>, IHandler<AccountRoleCreateCommand>
{
    private readonly IAccountRoleCreateRepository _repositoryAccountRoleCreate;

    public AccountRoleCreateHandler(IAccountRoleCreateRepository repositoryAccountRoleCreate)
    {
        _repositoryAccountRoleCreate = repositoryAccountRoleCreate;
    }

    public ICommandResult Handle(AccountRoleCreateCommand command)
    {
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

        Role role;
        try
        {
            role = new Role(command.Title);
        }
        catch
        {
            return new CommandResult(false, "Ops, falha ao verificar requisição!", command.Notifications);
        }
        try
        {
            var exists = _repositoryAccountRoleCreate.AnyAsync(command.Title);
            if (exists.Result)
                return new CommandResult(false, "Ops, falha role já cadastrado!", command.Notifications);
        }
        catch
        {
            return new CommandResult(false, "Falha ao verificar role cadastrado", command.Notifications);
        }
        try
        {
            _repositoryAccountRoleCreate.SaveAsync(role);
        }
        catch
        {
            return new CommandResult(false, "Falha ao persistir dados", command.Notifications);
        }
        return new CommandResult(true, "Conta criada com sucesso!", role);
    }
}
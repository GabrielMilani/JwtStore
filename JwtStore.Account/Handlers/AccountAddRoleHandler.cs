using Flunt.Notifications;
using JwtStore.Account.Commands;
using JwtStore.Account.Entities;
using JwtStore.Account.Repositories;
using JwtStore.Shared.Commands;
using JwtStore.Shared.Handlers;

namespace JwtStore.Account.Handlers;

public class AccountAddRoleHandler : Notifiable<Notification>, IHandler<AccountAddRoleCommand>
{
    private readonly IAccountAddRoleRepository _repositoryAccountAddRole;

    public AccountAddRoleHandler(IAccountAddRoleRepository repositoryAccountAddRole)
    {
        _repositoryAccountAddRole = repositoryAccountAddRole;
    }

    public ICommandResult Handle(AccountAddRoleCommand command)
    {
        try
        {
            command.Validate();
            if (!command.IsValid)
                return new CommandResult(false, "Ops, falha ao autenticar Usuário!", command.Notifications);
        }
        catch
        {
            return new CommandResult(false, "Ops, falha ao verificar requisição!", command.Notifications);
        }

        User? user;
        Role? role;
        try
        {
            user = _repositoryAccountAddRole.GetUserByEmailAsync(command.Email).Result;
            if (user is null)
                return new CommandResult(false, "Perfil não encontrado", command.Notifications);
        }
        catch
        {
            return new CommandResult(false, "Não foi possível recuperar seu perfil", command.Notifications);
        }

        try
        {
            role = _repositoryAccountAddRole.GetRoleByTitleAsync(command.Role).Result;
            if (role is null)
                return new CommandResult(false, "Role não encontrado", command.Notifications);
        }
        catch
        {
            return new CommandResult(false, "Não foi enconcontra seu Role", command.Notifications);
        }

        try
        {
            user.AddRoles(role);
        }
        catch
        {
            return new CommandResult(false, "Não foi possível recuperar seu perfil", command.Notifications);
        }

        try
        {
            _repositoryAccountAddRole.SaveAsync(user);
        }
        catch
        {
            return new CommandResult(false, "Não foi possível salvar inserção de role", command.Notifications);
        }
        return new CommandResult(true, "Inserção de role efetuado com sucesso!", user);
    }
}
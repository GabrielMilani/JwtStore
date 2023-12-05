using Flunt.Notifications;
using JwtStore.Account.Commands;
using JwtStore.Account.Commands.Results;
using JwtStore.Account.Commands.Results.Response;
using JwtStore.Account.Entities;
using JwtStore.Account.Repositories;
using JwtStore.Shared.Commands;
using JwtStore.Shared.Handlers;

namespace JwtStore.Account.Handlers;

public class AccountInsertRoleHandler : Notifiable<Notification>, IHandler<AccountInsertRoleCommand>
{
    private readonly IAccountInsertRoleRepository _repositoryAccountInsertRole;

    public AccountInsertRoleHandler(IAccountInsertRoleRepository repositoryAccountInsertRole)
    {
        _repositoryAccountInsertRole = repositoryAccountInsertRole;
    }

    public ICommandResult Handle(AccountInsertRoleCommand command)
    {
        #region 01. Valida a requisição.
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
        #endregion

        #region 02. Recupera perfil do usuário.
        User? user;
        try
        {
            user = _repositoryAccountInsertRole.GetUserByEmailAsync(command.Email).Result;
            if (user is null)
                return new CommandResult(false, "Perfil não encontrado", command.Notifications);
        }
        catch
        {
            return new CommandResult(false, "Não foi possível recuperar seu perfil", command.Notifications);
        }
        #endregion

        #region 03. Recupera o role.

        Role? role;
        try
        {
            role = _repositoryAccountInsertRole.GetRoleByTitleAsync(command.Role).Result;
            if (role is null)
                return new CommandResult(false, "Role não encontrado", command.Notifications);
        }
        catch
        {
            return new CommandResult(false, "Não foi enconcontra seu Role", command.Notifications);
        }
        #endregion

        #region 04. Adiciona roles ao usuário.
        try
        {
            user.Roles.Add(role);
        }
        catch
        {
            return new CommandResult(false, "Não foi possível recuperar seu perfil", command.Notifications);
        }
        #endregion

        #region 05. Perciste as alterações no banco.
        try
        {
            _repositoryAccountInsertRole.SaveAsync(user);
        }
        catch
        {
            return new CommandResult(false, "Não foi possível salvar inserção de role", command.Notifications);
        }
        #endregion

        var listRoleResponse = new List<RoleResponse>();
        foreach (var roleResponse in user.Roles)
        {
            listRoleResponse.Add(new RoleResponse(role.Id, role.Title));
        }
        return new AccountRoleCommandResult(true, "Roles add success!", listRoleResponse);
    }
}
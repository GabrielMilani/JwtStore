﻿using Flunt.Notifications;
using JwtStore.Account.Commands;
using JwtStore.Account.Commands.Results;
using JwtStore.Account.Commands.Results.Response;
using JwtStore.Account.Entities;
using JwtStore.Account.Repositories;
using JwtStore.Shared.Commands;
using JwtStore.Shared.Handlers;

namespace JwtStore.Account.Handlers;

public class RoleCreateHandler : Notifiable<Notification>, IHandler<RoleCreateCommand>
{
    private readonly IRoleCreateRepository _repositoryAccountCreateRole;

    public RoleCreateHandler(IRoleCreateRepository repositoryAccountCreateRole)
    {
        _repositoryAccountCreateRole = repositoryAccountCreateRole;
    }

    public ICommandResult Handle(RoleCreateCommand command)
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

        #region 02. Recebe dados role.
        Role role;
        try
        {
            role = new Role(command.Title);
        }
        catch
        {
            return new CommandResult(false, "Ops, falha ao verificar requisição!", command.Notifications);
        }
        #endregion

        #region 03. Valida se titulo do role ja cadastrado.
        try
        {
            var exists = _repositoryAccountCreateRole.AnyAsync(command.Title);
            if (exists.Result)
                return new CommandResult(false, "Ops, falha role já cadastrado!", command.Notifications);
        }
        catch
        {
            return new CommandResult(false, "Falha ao verificar role cadastrado", command.Notifications);
        }
        #endregion

        #region 04. Persiste role no banco.
        try
        {
            _repositoryAccountCreateRole.SaveAsync(role);
        }
        catch
        {
            return new CommandResult(false, "Falha ao persistir dados", command.Notifications);
        }
        #endregion 

        var roleResponse = new RoleResponse(role.Id, role.Title);
        var listRoleResponse = new List<RoleResponse>();
        listRoleResponse.Add(roleResponse);

        return new RoleCommandResult(true, "Conta criada com sucesso!", listRoleResponse);
    }
}
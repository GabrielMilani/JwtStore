using Flunt.Notifications;
using JwtStore.Account.Commands;
using JwtStore.Account.Entities;
using JwtStore.Account.Repositories;
using JwtStore.Account.ValueObjects;
using JwtStore.Shared.Commands;
using JwtStore.Shared.Handlers;
using SecureIdentity.Password;

namespace JwtStore.Account.Handlers;

public class AccountCreateHandler : Notifiable<Notification>, IHandler<AccountCreateCommand>
{
    private readonly IAccountCreateRepository _repositoryAccountCreate;

    public AccountCreateHandler(IAccountCreateRepository repositoryAccountCreate)
    {
        _repositoryAccountCreate = repositoryAccountCreate;
    }

    public ICommandResult Handle(AccountCreateCommand command)
    {
        #region 01. Valida a requisição.
        try
        {
            command.Validate();
            if (!command.IsValid)
                return new CommandResult(false, "Ops, falha ao cadastrar Usuário!", command.Notifications);
        }
        catch
        {
            return new CommandResult(false, "Ops, falha ao verificar requisição!", command.Notifications);
        }
        #endregion

        #region 02. Recebe perfil do usuário.
        Email email;
        Password password;
        User user;

        try
        {
            email = new Email(command.Email);
            password = new Password(PasswordHasher.Hash(command.Password));
            user = new User(command.Name, email, password);
        }
        catch
        {
            return new CommandResult(false, "Ops, falha ao cadastrar Usuário!", command.Notifications);
        }
        #endregion

        #region 03. Valida se email ja existe cadastrado. 
        try
        {
            var exists = _repositoryAccountCreate.AnyAsync(command.Email);
            if (exists.Result)
                return new CommandResult(false, "Ops, falha E-mail já cadastrado!", command.Notifications);
        }
        catch
        {
            return new CommandResult(false, "Falha ao verificar E-mail cadastrado", command.Notifications);
        }
        #endregion

        #region 04. Persiste o perfil do usuário no banco.
        try
        {
            _repositoryAccountCreate.SaveAsync(user);
        }
        catch
        {
            return new CommandResult(false, "Falha ao persistir dados", command.Notifications);
        }
        #endregion

        return new CommandResult(true, "Conta criada com sucesso!", user);

    }
}
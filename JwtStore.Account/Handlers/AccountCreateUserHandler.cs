using Flunt.Notifications;
using JwtStore.Account.Commands;
using JwtStore.Account.Commands.Results;
using JwtStore.Account.Entities;
using JwtStore.Account.Repositories;
using JwtStore.Account.ValueObjects;
using JwtStore.Shared.Commands;
using JwtStore.Shared.Handlers;
using SecureIdentity.Password;

namespace JwtStore.Account.Handlers;

public class AccountCreateUserHandler : Notifiable<Notification>, IHandler<AccountCreateUserCommand>
{
    private readonly IAccountCreateUserRepository _userRepositoryAccountCreateUser;

    public AccountCreateUserHandler(IAccountCreateUserRepository userRepositoryAccountCreateUser)
    {
        _userRepositoryAccountCreateUser = userRepositoryAccountCreateUser;
    }

    public ICommandResult Handle(AccountCreateUserCommand command)
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
            var exists = _userRepositoryAccountCreateUser.AnyAsync(command.Email);
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
            _userRepositoryAccountCreateUser.SaveAsync(user);
        }
        catch
        {
            return new CommandResult(false, "Falha ao persistir dados", command.Notifications);
        }
        #endregion

        return new AccountCreateCommandResult(true, "Account created success!", user.Name, user.Email, user.Password.Hash);

    }
}
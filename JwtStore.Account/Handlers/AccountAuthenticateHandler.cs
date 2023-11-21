using Flunt.Notifications;
using JwtStore.Account.Commands;
using JwtStore.Account.Entities;
using JwtStore.Account.Repositories;
using JwtStore.Shared.Commands;
using JwtStore.Shared.Handlers;
using SecureIdentity.Password;

namespace JwtStore.Account.Handlers;

public class AccountAuthenticateHandler : Notifiable<Notification>, IHandler<AccountAuthenticateCommand>
{
    private readonly IAccountAuthenticateRepository _repositoryAccountAuthenticate;

    public AccountAuthenticateHandler(IAccountAuthenticateRepository repositoryAccountAuthenticate)
    {
        _repositoryAccountAuthenticate = repositoryAccountAuthenticate;
    }

    public ICommandResult Handle(AccountAuthenticateCommand command)
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
        try
        {
            user = _repositoryAccountAuthenticate.GetUserByEmailAsync(command.Email);
            if (user is null)
                return new CommandResult(false, "Perfil não encontrado", command.Notifications);
        }
        catch
        {
            return new CommandResult(false, "Não foi possível recuperar seu perfil", command.Notifications);
        }
        try
        {
            if (!PasswordHasher.Verify(command.Password, user.Password.Hash))
                if (user is null)
                    return new CommandResult(false, "Senha inválida", command.Notifications);
        }
        catch
        {
            return new CommandResult(false, "Não foi possível recuperar seu perfil", command.Notifications);
        }
        return new CommandResult(true, "Login efetuado com sucesso!", user);
    }

}
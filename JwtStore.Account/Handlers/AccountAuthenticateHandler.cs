using Flunt.Notifications;
using JwtStore.Account.Commands;
using JwtStore.Account.Entities;
using JwtStore.Account.Repositories;
using JwtStore.Account.Services;
using JwtStore.Shared;
using JwtStore.Shared.Commands;
using JwtStore.Shared.Handlers;
using SecureIdentity.Password;

namespace JwtStore.Account.Handlers;

public class AccountAuthenticateHandler : Notifiable<Notification>, IHandler<AccountAuthenticateCommand>
{
    private readonly IAccountAuthenticateRepository _repositoryAccountAuthenticate;
    private readonly IAccountAuthenticateTokenService _tokenServiceAccountAuthenticate;
    public AccountAuthenticateHandler(IAccountAuthenticateRepository repositoryAccountAuthenticate,
                                      IAccountAuthenticateTokenService accountAuthenticateTokenService)
    {
        _repositoryAccountAuthenticate = repositoryAccountAuthenticate;
        _tokenServiceAccountAuthenticate = accountAuthenticateTokenService;
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
            user = _repositoryAccountAuthenticate.GetUserByEmailAsync(command.Email).Result;
            if (user is null)
                return new CommandResult(false, "Perfil não encontrado", command.Notifications);
        }
        catch
        {
            return new CommandResult(false, "Não foi possível recuperar seu perfil", command.Notifications);
        }
        try
        {
            if (!PasswordHasher.Verify(user.Password.Hash, command.Password))
                return new CommandResult(false, "Senha inválida", command.Notifications);
        }
        catch
        {
            return new CommandResult(false, "Não foi possível recuperar seu perfil", command.Notifications);
        }
        string token;
        try
        {
            token = _tokenServiceAccountAuthenticate.GenerateToken(user);
        }
        catch
        {
            return new CommandResult(false, "Não foi possível gerar seu token de altentificação", command.Notifications);
        }
        return new CommandResult(true, "Login efetuado com sucesso!", token, user);
    }

}
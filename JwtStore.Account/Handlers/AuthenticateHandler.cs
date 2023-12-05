using Flunt.Notifications;
using JwtStore.Account.Commands;
using JwtStore.Account.Commands.Results;
using JwtStore.Account.Entities;
using JwtStore.Account.Repositories;
using JwtStore.Account.Services;
using JwtStore.Shared.Commands;
using JwtStore.Shared.Handlers;
using SecureIdentity.Password;

namespace JwtStore.Account.Handlers;

public class AuthenticateHandler : Notifiable<Notification>, IHandler<AuthenticateCommand>
{
    private readonly IAuthenticateRepository _repositoryAccountAuthenticate;
    private readonly IAuthenticateTokenService _tokenServiceAccountAuthenticate;
    public AuthenticateHandler(IAuthenticateRepository repositoryAccountAuthenticate,
                                      IAuthenticateTokenService accountAuthenticateTokenService)
    {
        _repositoryAccountAuthenticate = repositoryAccountAuthenticate;
        _tokenServiceAccountAuthenticate = accountAuthenticateTokenService;
    }

    public ICommandResult Handle(AuthenticateCommand command)
    {
        #region 01. Valida a requisição
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

        #region 02. Recupera perfil do usuário
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
        #endregion

        #region 03. Verifica senha do usuário
        try
        {
            if (!PasswordHasher.Verify(user.Password.Hash, command.Password))
                return new CommandResult(false, "Senha inválida", command.Notifications);
        }
        catch
        {
            return new CommandResult(false, "Não foi possível recuperar seu perfil", command.Notifications);
        }
        #endregion

        #region 04. Gera token de Autenticação
        string token;
        try
        {
            token = _tokenServiceAccountAuthenticate.GenerateToken(user);
        }
        catch
        {
            return new CommandResult(false, "Não foi possível gerar seu token de altentificação", command.Notifications);
        }
        #endregion

        return new AuthenticateCommandResult(true, "Login success!", user.Name, user.Email, token);
    }

}
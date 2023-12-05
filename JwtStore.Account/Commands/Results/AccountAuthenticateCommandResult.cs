using JwtStore.Shared.Commands;

namespace JwtStore.Account.Commands.Results;

public class AccountAuthenticateCommandResult : ICommandResult
{
    public AccountAuthenticateCommandResult() { }

    public AccountAuthenticateCommandResult(bool? success, string? message, string? name, string? email, string? token)
    {
        Success = success;
        Message = message;
        Name = name;
        Email = email;
        Token = token;
    }

    public bool? Success { get; set; }
    public string? Message { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Token { get; set; }

}
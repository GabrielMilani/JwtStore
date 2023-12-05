using JwtStore.Shared.Commands;

namespace JwtStore.Account.Commands.Results;

public class UserCommandResult : ICommandResult
{
    public UserCommandResult(bool? success, string? message, string? name, string? email, string? password)
    {
        Success = success;
        Message = message;
        Name = name;
        Email = email;
        Password = password;
    }

    public bool? Success { get; set; }
    public string? Message { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}
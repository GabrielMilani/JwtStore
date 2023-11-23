namespace JwtStore.Shared.Commands;

public class CommandResult : ICommandResult
{
    public CommandResult() { }

    public CommandResult(bool? success, string? message)
    {
        Success = success;
        Message = message;
    }

    public CommandResult(bool? success, string? message, object? data)
    {
        Success = success;
        Message = message;
        Data = data;
    }

    public CommandResult(bool? success, string? message, string? token, object? data)
    {
        Success = success;
        Message = message;
        Token = token;
        Data = data;
    }

    public bool? Success { get; set; }
    public string? Message { get; set; }
    public string? Token { get; set; }
    public object? Data { get; set; }
}
using JwtStore.Shared.Commands;

namespace JwtStore.Stock.Commands;

public class CommandResultStock : ICommandResult
{
    public CommandResultStock() { }

    public CommandResultStock(bool? success, string? message)
    {
        Success = success;
        Message = message;
    }

    public CommandResultStock(bool? success, string? message, object? data)
    {
        Success = success;
        Message = message;
        Data = data;
    }

    public CommandResultStock(bool? success, string? message, string? token, object? data)
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
using JwtStore.Account.Commands.Results.Response;
using JwtStore.Shared.Commands;

namespace JwtStore.Account.Commands.Results;

public class AddressCommandResult : ICommandResult
{
    public AddressCommandResult(bool? success, string? message, List<AddressResponse> addresses)
    {
        Success = success;
        Message = message;
        Addresses = addresses;
    }

    public bool? Success { get; set; }
    public string? Message { get; set; }
    public List<AddressResponse> Addresses { get; set; }
}
using JwtStore.Account.Commands.Results.Response;
using JwtStore.Shared.Commands;

namespace JwtStore.Account.Commands.Results;

public class AccountRoleCommandResult : ICommandResult
{
    public AccountRoleCommandResult(bool? success, string? message, List<RoleResponse> roles)
    {
        Success = success;
        Message = message;
        Roles = roles;
    }

    public bool? Success { get; set; }
    public string? Message { get; set; }
    public List<RoleResponse> Roles { get; set; }
}
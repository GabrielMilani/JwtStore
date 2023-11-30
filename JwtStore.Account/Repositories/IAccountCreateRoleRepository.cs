using JwtStore.Account.Entities;

namespace JwtStore.Account.Repositories;

public interface IAccountCreateRoleRepository
{
    Task<bool> AnyAsync(string title);
    Task SaveAsync(Role role);
}
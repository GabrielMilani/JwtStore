using JwtStore.Account.Entities;

namespace JwtStore.Account.Repositories;

public interface IAccountRoleCreateRepository
{
    Task<bool> AnyAsync(string title);
    Task SaveAsync(Role role);
}
using JwtStore.Account.Entities;

namespace JwtStore.Account.Repositories;

public interface IAccountCreateRepository
{
    Task<bool> AnyAsync(string email);
    Task SaveAsync(User user);
}
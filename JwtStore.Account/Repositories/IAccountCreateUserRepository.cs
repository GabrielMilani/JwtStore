using JwtStore.Account.Entities;

namespace JwtStore.Account.Repositories;

public interface IAccountCreateUserRepository
{
    Task<bool> AnyAsync(string email);
    Task SaveAsync(User user);
}
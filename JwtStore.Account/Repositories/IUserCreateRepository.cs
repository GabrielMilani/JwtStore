using JwtStore.Account.Entities;

namespace JwtStore.Account.Repositories;

public interface IUserCreateRepository
{
    Task<bool> AnyAsync(string email);
    Task SaveAsync(User user);
}
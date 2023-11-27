using JwtStore.Account.Entities;

namespace JwtStore.Account.Repositories;

public interface IAccountAuthenticateRepository
{
    Task<User?> GetUserByEmailAsync(string email);
}
using JwtStore.Account.Entities;

namespace JwtStore.Account.Repositories;

public interface IAuthenticateRepository
{
    Task<User?> GetUserByEmailAsync(string email);
}
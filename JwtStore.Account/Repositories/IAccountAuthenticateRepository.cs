using JwtStore.Account.Entities;

namespace JwtStore.Account.Repositories;

public interface IAccountAuthenticateRepository
{
    User? GetUserByEmailAsync(string email);
}
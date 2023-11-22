using JwtStore.Account.Entities;

namespace JwtStore.Account.Services;

public interface IAccountAuthenticateTokenService
{
    string GenerateToken(User user);
}
using JwtStore.Account.Entities;

namespace JwtStore.Account.Services;

public interface IAuthenticateTokenService
{
    string GenerateToken(User user);
}
using JwtStore.Shared.ValueObjects;
using SecureIdentity.Password;

namespace JwtStore.Account.ValueObjects;

public class Password : ValueObject
{
    public Password(string hash)
    {
        Hash = hash;
    }
    public string Hash { get; }
    public string ResetCode { get; } = Guid.NewGuid().ToString("N")[..8].ToUpper();
}
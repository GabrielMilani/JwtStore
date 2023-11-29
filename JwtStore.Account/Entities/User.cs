using JwtStore.Account.ValueObjects;
using JwtStore.Shared.Entities;

namespace JwtStore.Account.Entities;

public class User : Entity
{
    private readonly IList<Role?> _roles;
    public User()
    {
        _roles = new List<Role?>();
    }

    public User(string name, Email email, Password password)
    {
        Name = name;
        Email = email;
        Password = password;
        _roles = new List<Role?>();
    }
    public string Name { get; private set; } = string.Empty;
    public Email Email { get; private set; } = null!;
    public Password Password { get; private set; } = null!;
    public IReadOnlyCollection<Role?> Roles => _roles.ToArray();

    public void UpdatePassword(string newPassword, string code)
    {
        if (!string.Equals(code.Trim(), Password.ResetCode.Trim(), StringComparison.CurrentCultureIgnoreCase))
            throw new Exception("Código de restauração inválido");

        var password = new Password(newPassword);
        Password = password;
    }
    public void UpdateEmail(string newEmail, string code)
    {
        if (!string.Equals(code.Trim(), Password.ResetCode.Trim(), StringComparison.CurrentCultureIgnoreCase))
            throw new Exception("Código de restauração inválido");

        var email = new Email(newEmail);
        Email = email;
    }

    public void AddRoles(Role role)
    {
        _roles.Add(role);
    }
}
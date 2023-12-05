using Flunt.Notifications;
using Flunt.Validations;
using JwtStore.Shared.Commands;

namespace JwtStore.Account.Commands;

public class RoleInsertCommand : Notifiable<Notification>, ICommand
{
    public RoleInsertCommand(string email, string role)
    {
        Email = email;
        Role = role;
    }

    public string Email { get; set; }
    public string Role { get; set; }
    public void Validate()
    {
        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsLowerThan(Role.Length, 40, "Password", "A senha deve conter menos que 40 caracteres")
            .IsGreaterThan(Role.Length, 6, "Password", "A senha deve conter mais que 6 caracteres")
            .IsEmail(Email, "Email", "E-mail inválido"));
    }
}